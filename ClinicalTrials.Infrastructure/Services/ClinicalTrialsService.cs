using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using AutoMapper;
using ClinicalTrials.Contracts.Data;
using ClinicalTrials.Contracts.Data.Entities;
using ClinicalTrials.Contracts.DTO;
using ClinicalTrials.Contracts.Enum;
using ClinicalTrials.Contracts.Models.Requests;
using ClinicalTrials.Contracts.Models.Responses;
using ClinicalTrials.Contracts.Services;
using ClinicalTrials.Core.Converters;
using ClinicalTrials.Core.Helpers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace ClinicalTrials.Infrastructure.Services;

public class ClinicalTrialsService(IUnitOfWork unitOfWork, IMapper mapper) : IClinicalTrialsService
{
    private readonly JSchema _jsonSchema = JSchema.Parse(File.ReadAllText("Files/jsonSchema.json"));

    public async Task<ClinicalTrialVM> GetClinicalTrialAsync(long id)
    {
        var entity = await unitOfWork.ClinicalTrialRepository.GetAsync(id);
        if (entity is null) throw new KeyNotFoundException($"Clinical trial with Id {id} not found");

        var result = mapper.Map<ClinicalTrialVM>(entity);
        return result;
    }

    public async Task<ClinicalTrialsFilterResponse> GetClinicalTrialsAsync(ClinicalTrialsFilterRequest model)
    {
        Expression<Func<ClinicalTrial, bool>> _expr = e =>
            e.EntityStatus == EntityStatus.Active;

        if (model.Keyword is not null)
            _expr = _expr.AndAlso(e => e.Title.Contains(model.Keyword));
        
        if (model.Status is not null)
            _expr = _expr.AndAlso(e => e.Status == model.Status);

        var entities = 
            await unitOfWork.ClinicalTrialRepository.GetAllAsync(_expr, (model.Page - 1) * model.PageSize,
            model.PageSize, e => e.Created, model.IsDescending);

        var count = await unitOfWork.ClinicalTrialRepository.CountAsync(_expr);
        var totalPages = (int)Math.Ceiling(decimal.Divide(count, model.PageSize));

        var сlinicalTrials = mapper.Map<List<ClinicalTrialVM>>(entities);

        var result = new ClinicalTrialsFilterResponse
        {
            ClinicalTrials = сlinicalTrials,
            Page = model.Page,
            PageSize = model.PageSize,
            TotalCount = count,
            ShowPrevious = model.Page > 1,
            ShowNext = model.Page < totalPages
        };

        return result;
    }

    public async Task<ClinicalTrialVM> AddClinicalTrialAsync(IFormFile file)
    {
        var json = await ReadFileAsync(file);

        var clinicalTrial = JsonConvert.DeserializeObject<ClinicalTrial>(json, new JsonSerializerSettings
        {
            Converters = { new TrialStatusConverter() }
        });
        if (clinicalTrial is null) throw new Exception("Invalid JSON data");

        // Convert DateTimeOffset properties to UTC
        clinicalTrial.StartDate = clinicalTrial.StartDate.ToUniversalTime();
        clinicalTrial.EndDate = clinicalTrial.EndDate.ToUniversalTime();

        await unitOfWork.ClinicalTrialRepository.AddAsync(clinicalTrial);
        await unitOfWork.CommitAsync();

        var result = mapper.Map<ClinicalTrialVM>(clinicalTrial);
        return result;
    }

    private async Task<string> ReadFileAsync(IFormFile file)
    {
        using var stream = new StreamReader(file.OpenReadStream());
        var json = await stream.ReadToEndAsync();
        var jsonObject = JObject.Parse(json);

        if (!jsonObject.IsValid(_jsonSchema, out IList<string> errorMessages))
        {
            throw new ValidationException("Invalid JSON data: " + string.Join(", ", errorMessages));
        }

        return json;
    }
}
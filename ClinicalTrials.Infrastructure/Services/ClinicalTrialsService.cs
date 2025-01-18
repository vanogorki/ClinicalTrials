using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ClinicalTrials.Contracts.Data;
using ClinicalTrials.Contracts.Data.Entities;
using ClinicalTrials.Contracts.DTO;
using ClinicalTrials.Contracts.Services;
using ClinicalTrials.Core.Converters;
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
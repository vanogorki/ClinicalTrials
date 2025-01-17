using AutoMapper;
using ClinicalTrials.Contracts.Data;
using ClinicalTrials.Contracts.Data.Entities;
using ClinicalTrials.Contracts.DTO;
using ClinicalTrials.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ClinicalTrials.Infrastructure.Services;

public class ClinicalTrialsService(IUnitOfWork unitOfWork, IMapper mapper) : IClinicalTrialsService
{
    public async Task<ClinicalTrialVM> GetClinicalTrialAsync(long id)
    {
        var entity = await unitOfWork.ClinicalTrialRepository.GetAsync(id);
        if (entity is null) throw new Exception("Clinical Trial not found");
        
        var result = mapper.Map<ClinicalTrialVM>(entity);
        return result;
    }

    public async Task<ClinicalTrialVM> AddClinicalTrialAsync(IFormFile file)
    {
        using var stream = new MemoryStream();
        await file.CopyToAsync(stream);
        stream.Position = 0;
        var json = await new StreamReader(stream).ReadToEndAsync();

        var clinicalTrial = JsonConvert.DeserializeObject<ClinicalTrial>(json);
        if (clinicalTrial is null) throw new Exception("Invalid JSON data");
        
        // Convert DateTimeOffset properties to UTC
        clinicalTrial.StartDate = clinicalTrial.StartDate.ToUniversalTime();
        clinicalTrial.EndDate = clinicalTrial.EndDate.ToUniversalTime();

        await unitOfWork.ClinicalTrialRepository.AddAsync(clinicalTrial);
        await unitOfWork.CommitAsync();

        var result = mapper.Map<ClinicalTrialVM>(clinicalTrial);
        return result;
    }
}
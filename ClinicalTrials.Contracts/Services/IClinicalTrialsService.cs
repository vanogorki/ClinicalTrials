using ClinicalTrials.Contracts.DTO;
using ClinicalTrials.Contracts.Models.Requests;
using ClinicalTrials.Contracts.Models.Responses;
using Microsoft.AspNetCore.Http;

namespace ClinicalTrials.Contracts.Services;

public interface IClinicalTrialsService
{
    Task<ClinicalTrialVM> GetClinicalTrialAsync(long id);
    Task<ClinicalTrialsFilterResponse> GetClinicalTrialsAsync(ClinicalTrialsFilterRequest model);
    Task<ClinicalTrialVM> AddClinicalTrialAsync(IFormFile file);
}
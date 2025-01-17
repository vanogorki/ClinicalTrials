using ClinicalTrials.Contracts.DTO;
using Microsoft.AspNetCore.Http;

namespace ClinicalTrials.Contracts.Services;

public interface IClinicalTrialsService
{
    Task<ClinicalTrialVM> GetClinicalTrialAsync(long id);
    Task<ClinicalTrialVM> AddClinicalTrialAsync(IFormFile file);
}
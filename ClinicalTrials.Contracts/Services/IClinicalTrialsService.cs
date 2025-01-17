using ClinicalTrials.Contracts.DTO;

namespace ClinicalTrials.Contracts.Services;

public interface IClinicalTrialsService
{
    Task<ClinicalTrialVM> GetClinicalTrialAsync(long id);
    Task<ClinicalTrialVM> AddClinicalTrialAsync(ClinicalTrialCOE clinicalTrial);
}
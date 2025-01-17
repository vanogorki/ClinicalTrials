using ClinicalTrials.Contracts.DTO;
using ClinicalTrials.Contracts.Services;

namespace ClinicalTrials.Infrastructure.Services;

public class ClinicalTrialsService : IClinicalTrialsService
{
    public Task<ClinicalTrialVM> GetClinicalTrialAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<ClinicalTrialVM> AddClinicalTrialAsync(ClinicalTrialCOE clinicalTrial)
    {
        throw new NotImplementedException();
    }
}
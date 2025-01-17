using ClinicalTrials.Contracts.Data;
using ClinicalTrials.Contracts.DTO;
using ClinicalTrials.Contracts.Services;

namespace ClinicalTrials.Infrastructure.Services;

public class ClinicalTrialsService(IUnitOfWork unitOfWork) : IClinicalTrialsService
{
    public async Task<ClinicalTrialVM> GetClinicalTrialAsync(long id)
    {
        var entity = await unitOfWork.ClinicalTrialRepository.GetAsync(1);
        if (entity is null) throw new Exception("Clinical Trial not found");
        var result = new ClinicalTrialVM();
        return result;
    }

    public Task<ClinicalTrialVM> AddClinicalTrialAsync(ClinicalTrialCOE clinicalTrial)
    {
        throw new NotImplementedException();
    }
}
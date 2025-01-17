using ClinicalTrials.Contracts.Data.Repositories;

namespace ClinicalTrials.Contracts.Data;

public interface IUnitOfWork
{
    IClinicalTrialRepository ClinicalTrialRepository { get; }
    Task CommitAsync();
}
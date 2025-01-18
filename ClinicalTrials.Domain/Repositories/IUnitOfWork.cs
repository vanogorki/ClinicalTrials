namespace ClinicalTrials.Domain.Repositories;

public interface IUnitOfWork
{
    IClinicalTrialRepository ClinicalTrialRepository { get; }
    Task CommitAsync();
}
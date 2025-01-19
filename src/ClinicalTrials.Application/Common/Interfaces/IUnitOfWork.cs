namespace ClinicalTrials.Application.Common.Interfaces;

public interface IUnitOfWork
{
    IClinicalTrialRepository ClinicalTrialRepository { get; }
    Task CommitAsync();
}
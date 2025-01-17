namespace ClinicalTrials.Contracts.DTO.Base;

public abstract class BaseEntityVM
{
    public long Id { get; set; }
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset? LastModified { get; set; }
}

namespace ClinicalTrials.Application.Features.Dtos;

public abstract class BaseEntityDto
{
    public long Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? LastModifiedAt { get; set; }
}
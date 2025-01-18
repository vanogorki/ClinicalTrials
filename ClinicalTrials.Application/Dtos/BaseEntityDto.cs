namespace ClinicalTrials.Application.Dtos;

public abstract record BaseEntityDto
{
    public long Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? LastModifiedAt { get; set; }
}
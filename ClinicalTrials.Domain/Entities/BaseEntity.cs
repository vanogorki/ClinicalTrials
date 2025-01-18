using ClinicalTrials.Domain.Enums;

namespace ClinicalTrials.Domain.Entities;

public abstract record BaseEntity
{
    public long Id { get; set; }
    public EntityStatus EntityStatus { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? LastModifiedAt { get; set; }
}
using ClinicalTrials.Domain.Enums;

namespace ClinicalTrials.Application.Features.Dtos;

public sealed class ClinicalTrialDto : BaseEntityDto
{
    public string TrialId { get; set; } = null!;
    public string Title { get; set; } = null!;
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public int Participants { get; set; }
    public TrialStatus Status { get; set; }
    public int DurationInDays { get; set; }
}
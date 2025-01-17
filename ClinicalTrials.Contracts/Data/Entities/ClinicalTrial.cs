using ClinicalTrials.Contracts.Data.Entities.Base;
using ClinicalTrials.Contracts.Enum;

namespace ClinicalTrials.Contracts.Data.Entities;

public class ClinicalTrial : BaseEntity
{
    public string Title { get; set; } = null!;
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public int Participants { get; set; }
    public TrialStatus Status { get; set; }
    public int DurationInDays { get; set; }
}
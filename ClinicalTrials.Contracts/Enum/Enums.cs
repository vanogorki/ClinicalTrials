using System.ComponentModel;

namespace ClinicalTrials.Contracts.Enum;

public enum EntityStatus
{
    [Description(nameof(Active))] Active = 1,
    [Description(nameof(Deleted))] Deleted = 2
}

public enum TrialStatus
{
    [Description(nameof(NotStarted))] NotStarted = 1,
    [Description(nameof(Ongoing))] Ongoing = 2,
    [Description(nameof(Completed))] Completed = 3
}
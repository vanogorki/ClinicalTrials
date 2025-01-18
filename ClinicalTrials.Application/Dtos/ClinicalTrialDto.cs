using ClinicalTrials.Domain.Enums;

namespace ClinicalTrials.Application.Dtos;

public record ClinicalTrialDto(
    string TrialId,
    string Title,
    DateTimeOffset StartDate,
    DateTimeOffset EndDate,
    int Participants,
    TrialStatus Status,
    int DurationInDays
) : BaseEntityDto;
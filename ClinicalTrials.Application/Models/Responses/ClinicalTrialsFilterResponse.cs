using ClinicalTrials.Application.Dtos;

namespace ClinicalTrials.Application.Models.Responses;

public sealed class ClinicalTrialsFilterResponse : PaginationFilterResponse
{
    public List<ClinicalTrialDto> ClinicalTrials { get; set; } = null!;
}
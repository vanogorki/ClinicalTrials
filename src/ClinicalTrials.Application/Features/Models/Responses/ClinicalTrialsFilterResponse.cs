using ClinicalTrials.Application.Features.Dtos;

namespace ClinicalTrials.Application.Features.Models.Responses;

public sealed class ClinicalTrialsFilterResponse : PaginationFilterResponse
{
    public List<ClinicalTrialDto> ClinicalTrials { get; set; } = null!;
}
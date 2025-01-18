using ClinicalTrials.Contracts.Enum;

namespace ClinicalTrials.Contracts.Models.Requests;

public class ClinicalTrialsFilterRequest : PaginationFilterRequest
{
    public string? Keyword { get; set; }
    public TrialStatus? Status { get; set; }
    public bool IsDescending { get; set; }
}
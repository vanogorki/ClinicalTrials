using ClinicalTrials.Contracts.DTO;

namespace ClinicalTrials.Contracts.Models.Responses;

public class ClinicalTrialsFilterResponse : PaginationFilterResponse
{
    public List<ClinicalTrialVM> ClinicalTrials { get; set; } = null!;
}
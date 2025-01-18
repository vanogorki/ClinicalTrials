﻿using ClinicalTrials.Domain.Enums;

namespace ClinicalTrials.Application.Models.Requests;

public sealed class ClinicalTrialsFilterRequest : PaginationFilterRequest
{
    public string? Keyword { get; set; }
    public TrialStatus? Status { get; set; }
    public bool IsDescending { get; set; }
}
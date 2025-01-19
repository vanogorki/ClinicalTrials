using ClinicalTrials.Application.Features.Models.Requests;
using ClinicalTrials.Application.Features.Models.Responses;
using MediatR;

namespace ClinicalTrials.Application.Features.Queries.GetClinicalTrials;

public sealed record GetClinicalTrialsQuery(ClinicalTrialsFilterRequest FilterRequest)
    : IRequest<ClinicalTrialsFilterResponse>;
using ClinicalTrials.Application.Models.Requests;
using ClinicalTrials.Application.Models.Responses;
using MediatR;

namespace ClinicalTrials.Application.Commands.GetClinicalTrials;

public sealed record GetClinicalTrialsRequest(ClinicalTrialsFilterRequest FilterRequest)
    : IRequest<ClinicalTrialsFilterResponse>;
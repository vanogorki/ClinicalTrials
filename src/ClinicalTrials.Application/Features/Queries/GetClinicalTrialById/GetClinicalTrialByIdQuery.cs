using ClinicalTrials.Application.Features.Dtos;
using MediatR;

namespace ClinicalTrials.Application.Features.Queries.GetClinicalTrialById;

public sealed record GetClinicalTrialByIdQuery(string TrialId) : IRequest<ClinicalTrialDto>;
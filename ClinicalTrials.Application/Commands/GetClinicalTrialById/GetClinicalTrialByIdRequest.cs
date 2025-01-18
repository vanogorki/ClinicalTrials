using ClinicalTrials.Application.Dtos;
using MediatR;

namespace ClinicalTrials.Application.Commands.GetClinicalTrialById;

public sealed record GetClinicalTrialByIdRequest(string TrialId) : IRequest<ClinicalTrialDto>;
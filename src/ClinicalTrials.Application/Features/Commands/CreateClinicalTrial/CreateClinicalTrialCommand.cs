using ClinicalTrials.Application.Features.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ClinicalTrials.Application.Features.Commands.CreateClinicalTrial;

public sealed record CreateClinicalTrialCommand(IFormFile File) : IRequest<ClinicalTrialDto>;
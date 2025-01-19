using System.Net;
using ClinicalTrials.Application.Common;
using ClinicalTrials.Application.Common.Attributes;
using ClinicalTrials.Application.Features.Commands.CreateClinicalTrial;
using ClinicalTrials.Application.Features.Dtos;
using ClinicalTrials.Application.Features.Models.Requests;
using ClinicalTrials.Application.Features.Models.Responses;
using ClinicalTrials.Application.Features.Queries.GetClinicalTrialById;
using ClinicalTrials.Application.Features.Queries.GetClinicalTrials;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalTrials.API.Controllers;

[ApiController]
[Route("api/clinicaltrials")]
public sealed class ClinicalTrialsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(ClinicalTrialsFilterResponse), (int)HttpStatusCode.OK)]
    [ProducesErrorResponseType(typeof(BaseApiResponse))]
    public async Task<IActionResult> Get([FromQuery] ClinicalTrialsFilterRequest model, CancellationToken ct)
    {
        var request = new GetClinicalTrialsQuery(model);
        var response = await mediator.Send(request, ct);
        
        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ClinicalTrialDto), (int)HttpStatusCode.OK)]
    [ProducesErrorResponseType(typeof(BaseApiResponse))]
    public async Task<IActionResult> GetById(string id, CancellationToken ct)
    {
        var request = new GetClinicalTrialByIdQuery(id);
        var response = await mediator.Send(request, ct);
        
        return Ok(response);
    }

    [HttpPost]
    [FileValidation([".json"], 1048576)]
    [ProducesResponseType(typeof(ClinicalTrialDto), (int)HttpStatusCode.Created)]
    [ProducesErrorResponseType(typeof(BaseApiResponse))]
    public async Task<IActionResult> Post(IFormFile file, CancellationToken ct)
    {
        var request = new CreateClinicalTrialCommand(file);
        var response = await mediator.Send(request, ct);

        return StatusCode((int)HttpStatusCode.Created, response);
    }
}
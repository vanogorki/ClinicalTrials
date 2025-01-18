using System.Net;
using ClinicalTrials.Application.Attributes;
using ClinicalTrials.Application.Commands.CreateClinicalTrial;
using ClinicalTrials.Application.Commands.GetClinicalTrialById;
using ClinicalTrials.Application.Commands.GetClinicalTrials;
using ClinicalTrials.Application.Common;
using ClinicalTrials.Application.Dtos;
using ClinicalTrials.Application.Models.Requests;
using ClinicalTrials.Application.Models.Responses;
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
        var request = new GetClinicalTrialsRequest(model);
        var response = await mediator.Send(request, ct);
        
        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ClinicalTrialDto), (int)HttpStatusCode.OK)]
    [ProducesErrorResponseType(typeof(BaseApiResponse))]
    public async Task<IActionResult> GetById(string id, CancellationToken ct)
    {
        var request = new GetClinicalTrialByIdRequest(id);
        var response = await mediator.Send(request, ct);
        
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ClinicalTrialDto), (int)HttpStatusCode.Created)]
    [ProducesErrorResponseType(typeof(BaseApiResponse))]
    public async Task<IActionResult> Post([AllowedFileExtensions([".json"])] [MaxFileSize(1048576)] IFormFile file,
        CancellationToken ct)
    {
        var request = new CreateClinicalTrialRequest(file);
        var response = await mediator.Send(request, ct);

        return StatusCode((int)HttpStatusCode.Created, response);
    }
}
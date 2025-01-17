using System.Net;
using ClinicalTrials.Contracts.Attributes;
using ClinicalTrials.Contracts.DTO;
using ClinicalTrials.Contracts.DTO.Base;
using ClinicalTrials.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalTrials.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClinicalTrialsController(IClinicalTrialsService clinicalTrialsService) : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ClinicalTrialVM), (int)HttpStatusCode.OK)]
    [ProducesErrorResponseType(typeof(BaseApiResponse))]
    public async Task<IActionResult> Get(int id)
    {
        var response = await clinicalTrialsService.GetClinicalTrialAsync(id);
        return Ok(response);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(ClinicalTrialVM), (int)HttpStatusCode.Created)]
    [ProducesErrorResponseType(typeof(BaseApiResponse))]
    public async Task<IActionResult> Post([AllowedFileExtensions([".json"])] IFormFile file)
    {
        var response = await clinicalTrialsService.AddClinicalTrialAsync(file);
        return StatusCode((int)HttpStatusCode.Created, response);
    }
}
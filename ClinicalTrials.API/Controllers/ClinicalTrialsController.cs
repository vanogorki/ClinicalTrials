using System.Net;
using ClinicalTrials.Contracts.Attributes;
using ClinicalTrials.Contracts.DTO;
using ClinicalTrials.Contracts.DTO.Base;
using ClinicalTrials.Contracts.Models.Requests;
using ClinicalTrials.Contracts.Models.Responses;
using ClinicalTrials.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalTrials.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClinicalTrialsController(IClinicalTrialsService clinicalTrialsService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(ClinicalTrialsFilterResponse), (int)HttpStatusCode.OK)]
    [ProducesErrorResponseType(typeof(BaseApiResponse))]
    public async Task<IActionResult> Get([FromQuery] ClinicalTrialsFilterRequest model)
    {
        var response = await clinicalTrialsService.GetClinicalTrialsAsync(model);
        return Ok(response);
    }
    
    [HttpGet]
    [Route("{id:long}")]
    [ProducesResponseType(typeof(ClinicalTrialVM), (int)HttpStatusCode.OK)]
    [ProducesErrorResponseType(typeof(BaseApiResponse))]
    public async Task<IActionResult> GetById(long id)
    {
        var response = await clinicalTrialsService.GetClinicalTrialAsync(id);
        return Ok(response);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(ClinicalTrialVM), (int)HttpStatusCode.Created)]
    [ProducesErrorResponseType(typeof(BaseApiResponse))]
    public async Task<IActionResult> Post([AllowedFileExtensions([".json"])] [MaxFileSize(1048576)] IFormFile file) // 1 MB max json file
    {
        var response = await clinicalTrialsService.AddClinicalTrialAsync(file);
        return StatusCode((int)HttpStatusCode.Created, response);
    }
}
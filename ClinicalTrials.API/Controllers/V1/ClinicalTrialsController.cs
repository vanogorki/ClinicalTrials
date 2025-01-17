using System.Net;
using ClinicalTrials.Contracts.DTO;
using ClinicalTrials.Contracts.DTO.Base;
using ClinicalTrials.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace ClinicalTrials.API.Controllers.V1;

[EnableRateLimiting("fixed")]
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
        var result = await clinicalTrialsService.GetClinicalTrialAsync(id);
        return Ok(result);
    }
}
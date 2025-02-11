using CDB.Domain.Services.Contracts;
using CDB.Domain.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CDB.WebApi.Controllers;

[ApiController]
[Route("api/cdb")]
public class CdbController : ControllerBase
{
    private readonly IPostCdbCalculate _service;

    public CdbController(IPostCdbCalculate service)
    {
        _service = service;
    }

    [HttpPost("calculate")]
    public async Task<IActionResult> PostCdbCalculateAsync([FromBody] PostCdbRequest request, CancellationToken cancellationToken)
    {
        var result = await _service.HandleAsync(request, cancellationToken);

        if (result.StatusCode == 200)
        {
            return Ok(result.Response);
        }

        return StatusCode(result.StatusCode, result.Response);
    }
}
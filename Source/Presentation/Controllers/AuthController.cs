using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCleanTemplate.Source.Presentation.Controllers;

[ApiController]
[Route("/api/auth")]
public class AuthController : ControllerBase
{
    /// <summary>
    /// A health check service
    /// </summary>
    /// <returns>200</returns>
    [HttpGet("")]
    [ProducesResponseType(200)]
    [AllowAnonymous]
    public async Task<IActionResult> HealthCheck()
    {
        return Ok(new { message = "working" });
    }
}
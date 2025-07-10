using DotNetCleanTemplate.Source.Domain.Services.Interfaces;
using DotNetCleanTemplate.Source.Infrastructure.Commons.Generics;
using DotNetCleanTemplate.Source.Presentation.Contracts.Requests.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCleanTemplate.Source.Presentation.Controllers;

[ApiController]
[Route("/api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) => this._authService = authService;

    /// <summary>
    /// A health check service
    /// </summary>
    /// <returns>200</returns>
    [HttpGet("")]
    [ProducesResponseType(200)]
    [AllowAnonymous]
    public async Task<IActionResult> HealthCheck()
    {
        return Ok(value: ResponseTemplate.MessageOnlyResponse("It's working"));
    }

    /// <summary>
    /// Register a new user
    /// </summary>
    [HttpPost("register")]
    [ProducesResponseType(typeof(RegisterUserResponse), 200)]
    [ProducesResponseType(400)]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
    {
        var registerResult = await _authService.RegisterUser(
            request.username,
            request.password,
            request.email,
            request.firstName,
            request.lastName);

        if (registerResult.IsSuccess) return Ok(ResponseTemplate.SuccessResponse("New user has been registered.", RegisterUserResponse.FromUser(registerResult.Value)));

        return BadRequest(ResponseTemplate.ErrorResponse(
            registerResult.ErrorMessage ?? "Something went wrong!",
            registerResult.Error));
    }

    [HttpPost("login")]
    [ProducesResponseType(200)]
    [ProducesResponseType(403)]
    [AllowAnonymous]
    public async Task<IActionResult> LoginUser([FromBody] LoginUserRequest request)
    {
        var loginRequest = await _authService.LoginUser(request.username, request.password);

        if (loginRequest.IsSuccess) return Ok(ResponseTemplate.SuccessResponse("Login successful", loginRequest.Value));

        return Unauthorized(ResponseTemplate.ErrorResponse(
                loginRequest.ErrorMessage ?? "There is no account with this username and password",
                loginRequest.Error));
    }
}

using Lab3.Infra.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lab3.API.Features.Authen;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AuthenController : ControllerBase
{

    private readonly AuthenHandler _handler;

    public AuthenController(AuthenHandler handler)
    {
        _handler = handler;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IResult> Login(LoginRequest request)
    {
        var query = request.Adapt<LoginQuery>();
        var result = await _handler.LoginHandler(query);

        var response = result.Adapt<LoginResponse>();

        return Results.Ok(response);
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IResult> Register(RegisterRequest request)
    {
        var command = request.Adapt<RegisterCommand>();
        var result = await _handler.RegisterHandler(command);

        var response = result.Adapt<RegisterResponse>();

        return Results.Ok(response);
    }

    [HttpPost("gen-jwt")]
    [AllowAnonymous]
    public IResult GenJwt(GenJwtRequest jwtRequest)
    {
        var claims = new Claim[]
        {
            new Claim("username", jwtRequest.Username),
            new Claim(ClaimTypes.NameIdentifier, "1"),
            new Claim(ClaimTypes.Role, jwtRequest.Role.ToString()),
        };

        var token = _handler.GenerateJSONWebToken(claims, jwtRequest.ValidInMinutes);

        return Results.Ok(new { Token = token });
    }
}

public record LoginRequest(string Username, string Password);
public record LoginResponse(string Token);

public record RegisterRequest(string Username, string Password);
public record RegisterResponse(bool IsSuccess);

public record GenJwtRequest(string Username, RoleEnum Role, int ValidInMinutes);
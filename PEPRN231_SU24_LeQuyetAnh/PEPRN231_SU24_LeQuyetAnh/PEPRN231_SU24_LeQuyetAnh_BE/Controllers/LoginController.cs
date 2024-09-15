using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PEPRN231_SU24_LeQuyetAnh_BE.Helper;
using PEPRN231_SU24_LeQuyetAnh_Library.Repo;
using System.Security.Claims;

namespace PEPRN231_SU24_LeQuyetAnh_BE.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class LoginController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;

    public LoginController(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginReq loginReq)
    {
        var email = loginReq.Email;
        var password = loginReq.Password;

        if (email is null || password is null)
        {
            return BadRequest(new { msg = "Username and password required!" });
        }

        var user = (await _unitOfWork
            .UserAccountRepo
            .GetAsync(u => u.UserPassword == password && u.UserEmail == email))
            .FirstOrDefault();

        if (user is null)
        {
            return Unauthorized(new { msg = "Username or password incorrect!" });
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, user.Role.ToString()!)
        };

        JwtHelper jwt = new();
        var token = jwt.GenerateJSONWebToken(claims);

        return Ok(new { Token = token });
    }
}

public record LoginReq(string Email, string Password);
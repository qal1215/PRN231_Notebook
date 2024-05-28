using FluentValidation;
using Lab3.API.Exceptions;
using Lab3.API.Helper;
using Lab3.Infra.Data;
using Lab3.Infra.Models;
using Mapster;
using System.Security.Claims;

namespace Lab3.API.Features.Authen;

public class AuthenHandler
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly JwtTokenHelper _jwtHelper;


    public AuthenHandler(IUnitOfWork unitOfWork, JwtTokenHelper jwtHelper)
    {
        _unitOfWork = unitOfWork;
        _jwtHelper = jwtHelper;
    }

    public async Task<LoginResult> LoginHandler(LoginQuery query)
    {
        var valid = new LoginQueryValidator().Validate(query);

        if (!valid.IsValid)
        {
            throw new ValidationException(valid.Errors);
        }

        var user = (await _unitOfWork.Accounts.GetAsync(a => a.Username == query.Username && a.Password == query.Password)).FirstOrDefault()
            ?? throw new AuthenticationException("Username or password invalid!");
        var claims = new Claim[]
        {
            new Claim("username", user.Username),
            new Claim(ClaimTypes.NameIdentifier,user.Accountid.ToString()!),
            new Claim(ClaimTypes.Role, user.Role.ToString()!),
        };

        var token = _jwtHelper.GenerateJSONWebToken(claims);

        var result = new LoginResult(token);
        return result;
    }

    public async Task<RegisterResult> RegisterHandler(RegisterCommand command)
    {
        var valid = new RegisterCommandValidator().Validate(command);
        if (!valid.IsValid)
        {
            throw new ValidationException(valid.Errors);
        }

        var account = command.Adapt<Account>();
        account.Role = Role.User;
        await _unitOfWork.Accounts.InsertAsync(account);
        await _unitOfWork.SaveAsync();

        return new RegisterResult(true);
    }

    public string GenerateJSONWebToken(Claim[] claims, int expireInMins)
    {
        return _jwtHelper.GenerateJSONWebToken(claims, expireInMins);
    }
}

public record LoginQuery(string Username, string Password);
public record LoginResult(string Token);

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}

public record RegisterCommand(string Username, string Password);
public record RegisterResult(bool IsSuccess);
public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}

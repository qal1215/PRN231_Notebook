using Lab3.API.Helper;
using Microsoft.AspNetCore.Authorization;

namespace Lab3.API.Middlewares;

public class AuthenMiddleware(JwtTokenHelper tokenHelper) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var endpoint = context.GetEndpoint();
        if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() is object)
        {
            await next(context);
            return;
        }

        //var authorizeData = endpoint?.Metadata?.GetMetadata<IAuthorizeData>();
        //if (authorizeData is object)
        //{
        //    await next(context);
        //    return;
        //}

        var authorHeader = context.Request.Headers["Authorization"];
        if (string.IsNullOrEmpty(authorHeader))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            throw new Exception("Unauthorized! Don't have authorization header!");
        }

        var token = authorHeader.ToString().Split(" ")[1];
        if (string.IsNullOrEmpty(token))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            throw new Exception("Unauthorized! Token is empty!");
        }

        var isValid = tokenHelper.ValidateJSONWebToken(token);
        if (!isValid)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            throw new Exception("Unauthorized! Token invalid!");
        }

        await next(context);
    }
}

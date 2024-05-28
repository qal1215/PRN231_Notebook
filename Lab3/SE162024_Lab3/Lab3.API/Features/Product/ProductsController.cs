using Lab3.API.Helper;
using Lab3.Infra.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.API.Features.Product;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly ProductsHandler _handler;
    private readonly JwtTokenHelper _tokenHelper;

    public ProductsController(ProductsHandler handler, JwtTokenHelper tokenHelper)
    {
        _handler = handler;
        _tokenHelper = tokenHelper;
    }

    [HttpPost("")]
    [Authorize(Roles = Role.Admin)]
    public IResult CreateProduct()
    {
        return Results.Ok(new { msg = "Okey, create product here!" });
    }

    [HttpGet("")]
    [AllowAnonymous]
    public IResult GetProducts()
    {
        return Results.Ok(new { msg = "Okey, get products here!" });
    }
}

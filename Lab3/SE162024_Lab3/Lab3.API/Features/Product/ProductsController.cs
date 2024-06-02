using Lab3.API.Models;
using Lab3.API.Models.Product;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.API.Features.Product;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly ProductsHandler _handler;

    public ProductsController(ProductsHandler handler)
    {
        _handler = handler;
    }

    [HttpPost("")]
    //[Authorize(Roles = Role.Admin)]
    [AllowAnonymous]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
    {
        var command = new CreateProductCommand(request.Product);
        var result = await _handler.CreateProduct(command);

        var response = new CreateProductResponse(result.Product.Adapt<ProductResponse>());
        return Created($"{result.Product.Id}", response);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetProductById(int id)
    {
        var query = new ProductByIdQuery(id);
        var result = await _handler.GetProductByIdHandler(query);

        var response = result.Adapt<GetProductByIdResponse>();

        return Ok(response);
    }

    [HttpGet("")]
    [AllowAnonymous]
    public async Task<IActionResult> GetProducts([FromQuery] PaginationRequest productsRequest)
    {
        var productsQuery = productsRequest.Adapt<ProductsQuery>();
        var result = await _handler.GetProductsHandler(productsQuery);

        var response = result.Adapt<GetProductsRespone>();

        return Ok(response);
    }

    [HttpDelete("{id}")]
    //[Authorize(Roles = Role.Admin)]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var command = new DeleteProductCommand(id);
        var result = await _handler.DeleteProductHandler(command);

        return Ok(result);
    }
}

//public record GetProductsRequest(int? PageIndex = 0, int? PageSize = 10, string? Search = "", string? OrderBy = "", bool? OrderDesc = false);
public record GetProductsRespone(IEnumerable<ProductResponse> Products, int Total, int PageIndex, int PageSize);

public record CreateProductRequest(ProductCreating Product);
public record CreateProductResponse(ProductResponse Product);

public record GetProductByIdResponse(ProductResponse Product);
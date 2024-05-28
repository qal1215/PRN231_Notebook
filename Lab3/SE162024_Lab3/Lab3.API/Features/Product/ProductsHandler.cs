using Lab3.API.Exceptions.Handler;
using Lab3.Infra.Data;

namespace Lab3.API.Features.Product;

public record ProductQuery(int id);
public record ProductResult(Infra.Models.Product Product);

public class ProductsHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductResult> GetProducts(ProductQuery query)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(query.id);
        if (product is null)
            throw new NotFoundException($"Product {query.id} not found");

        return new ProductResult(product);
    }
}

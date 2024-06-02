using Lab3.API.Exceptions.Handler;
using Lab3.API.Models.Product;
using Lab3.Infra.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lab3.API.Features.Product;

public class ProductsHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductByIdResult> GetProductByIdHandler(ProductByIdQuery query)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(query.Id);
        if (product is null)
            throw new NotFoundException($"Product {query.Id} not found");

        return new ProductByIdResult(product);
    }

    public async Task<ProductsResult> GetProductsHandler(ProductsQuery productsQuery)
    {
        var orderBySelectors = new Dictionary<string, Expression<Func<Infra.Models.Product, object>>>
        {
            { "price", p => p.UnitPrice },
            { "name", p => p.Name },
            {"category-name", p =>  p.Category.Name },
        };

        IQueryable<Infra.Models.Product> queryable = _unitOfWork.Products.GetQueryable();

        if (!string.IsNullOrEmpty(productsQuery.Search))
        {
            queryable = queryable.Where(p => p.Name.ToLower().Contains(productsQuery.Search.ToLower()));
        }

        if (!string.IsNullOrEmpty(productsQuery.OrderBy))
        {
            queryable = productsQuery.OrderDesc
                ? queryable.OrderByDescending(orderBySelectors[productsQuery.OrderBy])
                : queryable.OrderBy(orderBySelectors[productsQuery.OrderBy]);
        }

        var total = await queryable.CountAsync();

        var result = await queryable
            .Include(p => p.Category)
            .Skip(productsQuery.PageIndex * productsQuery.PageSize)
            .Take(productsQuery.PageSize)
            .ToListAsync();

        return new ProductsResult(result, total, productsQuery.PageIndex, productsQuery.PageSize);
    }

    public async Task<CreateProductResult> CreateProduct(CreateProductCommand command)
    {
        var isExistedCategory = await _unitOfWork.Categories.IsExist(command.Product.CategoryId);
        if (!isExistedCategory)
            throw new NotFoundException($"Category {command.Product.CategoryId} not found");

        var product = command.Product.Adapt<Infra.Models.Product>();
        await _unitOfWork.Products.InsertAsync(product);
        await _unitOfWork.SaveAsync();

        var result = new CreateProductResult(product);
        return result;
    }

    public async Task<DeleteProductResult> DeleteProductHandler(DeleteProductCommand command)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(command.ProductId);
        if (product is null)
            throw new NotFoundException($"Product {command.ProductId} not found");

        await _unitOfWork.Products.Delete(product);
        await _unitOfWork.SaveAsync();

        return new DeleteProductResult(true);
    }
}

public record ProductsQuery(int PageIndex = 0, int PageSize = 10, string Search = "", string OrderBy = "", bool OrderDesc = false);
public record ProductsResult(IEnumerable<Infra.Models.Product> Products, int Total, int PageIndex, int PageSize);

public record ProductByIdQuery(int Id);
public record ProductByIdResult(Infra.Models.Product Product);

public record CreateProductCommand(ProductCreating Product);
public record CreateProductResult(Infra.Models.Product Product);

public record DeleteProductCommand(int ProductId);
public record DeleteProductResult(bool IsDeleted);
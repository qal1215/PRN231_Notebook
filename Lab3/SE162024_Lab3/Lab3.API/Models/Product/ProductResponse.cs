namespace Lab3.API.Models.Product;

public record ProductResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int UnitsInStock { get; set; }

    public decimal UnitPrice { get; set; }

    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;
}

namespace Lab3.API.Models.Product;

public class ProductCreating
{
    public string Name { get; set; } = null!;
    public int UnitsInStock { get; set; }
    public decimal UnitPrice { get; set; }
    public int CategoryId { get; set; }
}

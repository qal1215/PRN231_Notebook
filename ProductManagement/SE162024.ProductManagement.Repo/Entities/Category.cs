namespace SE162024.ProductManagement.Repo.Entities;

public class Category
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoryId { get; set; }

    [Required]
    [StringLength(40)]
    public string CategoryName { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}


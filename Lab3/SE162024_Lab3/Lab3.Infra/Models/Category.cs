using System;
using System.Collections.Generic;

namespace Lab3.Infra.Models;

public partial class Category
{
    public int Categoryid { get; set; }

    public string Categoryname { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

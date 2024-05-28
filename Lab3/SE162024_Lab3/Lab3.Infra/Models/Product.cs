using System;
using System.Collections.Generic;

namespace Lab3.Infra.Models;

public partial class Product
{
    public int Productid { get; set; }

    public string Productname { get; set; } = null!;

    public int Unitsinstock { get; set; }

    public decimal Unitprice { get; set; }

    public int Categoryid { get; set; }

    public virtual Category Category { get; set; } = null!;
}

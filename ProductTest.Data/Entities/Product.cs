using System;
using System.Collections.Generic;

namespace ProductTest.Data.Entities;

public partial class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid CategoryId { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public bool Active { get; set; }

    public virtual Category Category { get; set; }
}

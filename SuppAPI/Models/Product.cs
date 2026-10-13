using System;
using System.Collections.Generic;

namespace SuppAPI.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Stock { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<BasketDetail> BasketDetails { get; set; } = new List<BasketDetail>();
}

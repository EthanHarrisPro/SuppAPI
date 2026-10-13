using System;
using System.Collections.Generic;

namespace SuppAPI.Models;

public partial class BasketDetail
{
    public int Id { get; set; }

    public int Quantity { get; set; }

    public int ProductId { get; set; }

    public int BasketId { get; set; }

    public virtual Basket Basket { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}

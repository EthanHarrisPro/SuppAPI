using System;
using System.Collections.Generic;

namespace SuppAPI.Models;

public partial class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int BasketId { get; set; }

    public virtual Basket Basket { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}

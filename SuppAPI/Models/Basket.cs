using System;
using System.Collections.Generic;

namespace SuppAPI.Models;

public partial class Basket
{
    public int Id { get; set; }

    public virtual ICollection<BasketDetail> BasketDetails { get; set; } = new List<BasketDetail>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

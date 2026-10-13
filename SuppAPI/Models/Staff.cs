using System;
using System.Collections.Generic;

namespace SuppAPI.Models;

public partial class Staff
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Number { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Level { get; set; }
}

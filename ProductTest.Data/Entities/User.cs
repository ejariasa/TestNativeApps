using System;
using System.Collections.Generic;

namespace ProductTest.Data.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public bool Active { get; set; }
}

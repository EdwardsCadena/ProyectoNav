using System;
using System.Collections.Generic;

namespace Proyecto.Core.Entities;

public class User
{
    public int Id { get; set; }

    public string User1 { get; set; }

    public string? Password { get; set; }

    public DateTime? DateCreation { get; set; }
}

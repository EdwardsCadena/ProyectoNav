using System;
using System.Collections.Generic;

namespace Proyecto.Core.Entities;

public partial class Ticket
{
    public int Id { get; set; }

    public string? CustomerName { get; set; }

    public DateTime? DepartureTime { get; set; }

    public DateTime? ArrivalTime { get; set; }

    public string? DepartureLocation { get; set; }

    public string? ArrivalLocation { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }
}

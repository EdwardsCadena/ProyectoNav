﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Core.DTOs
{
    public class TicketDTOs
    {
        public string? CustomerName { get; set; }

        public DateTime? DepartureTime { get; set; }

        public DateTime? ArrivalTime { get; set; }

        public string? DepartureLocation { get; set; }

        public string? ArrivalLocation { get; set; }

    }
}

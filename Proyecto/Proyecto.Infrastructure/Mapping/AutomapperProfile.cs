using AutoMapper;
using Proyecto.Core.DTOs;
using Proyecto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proyecto.Infrastructure.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            // Estas líneas crean mapas bidireccionales entre las entidades y sus correspondientes DTOs
            // //con esto puedo mapear un objeto Teacher a un objeto TeacherDTOs y viceversa
            CreateMap<Ticket, TicketDTOs>();
            CreateMap<TicketDTOs, Ticket>();

            CreateMap<User, UserDTOs>();
            CreateMap<UserDTOs, User>();

        }
    }
}

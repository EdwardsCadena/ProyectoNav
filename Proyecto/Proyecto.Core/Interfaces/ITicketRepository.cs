using Proyecto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Core.Interfaces
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetTickets();
        Task<Ticket> GetTicket(int id);
        Task InsertTicket(Ticket ticket, string UserEmail);
        Task<bool> UpdateTicket(Ticket ticket, string UserEmail);
        Task<bool> DeleteTicket(int id);
    }
}

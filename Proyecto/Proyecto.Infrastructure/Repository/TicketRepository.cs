using Microsoft.EntityFrameworkCore;
using Proyecto.Core.Entities;
using Proyecto.Core.Interfaces;
using Proyecto.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Infrastructure.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly PruebaContext _context;
        DateTime currentDate = DateTime.Now;
        public TicketRepository(PruebaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Ticket>> GetTickets()
        {
            var tickets = await _context.Tickets.ToListAsync();
            return tickets;
        }
        public async Task<Ticket> GetTicket(int id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            return ticket;
        }
        public async Task InsertTicket(Ticket ticket, string UserEmail)
        {

            Ticket register = new Ticket
            {
                CustomerName = ticket.CustomerName,
                DepartureTime = ticket.DepartureTime,
                ArrivalTime = ticket.ArrivalTime,
                DepartureLocation = ticket.DepartureLocation,
                ArrivalLocation = ticket.ArrivalLocation,
                CreatedAt = currentDate,
                CreatedBy = UserEmail,
            };
            _context.Tickets.Add(register);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateTicket(Ticket ticket, string UserEmail)
        {
            var result = await GetTicket(ticket.Id);
            result.CustomerName = ticket.CustomerName;
            result.DepartureTime = ticket.DepartureTime;
            result.ArrivalTime = ticket.ArrivalTime;
            result.DepartureLocation = ticket.DepartureLocation;
            result.ArrivalLocation = ticket.ArrivalLocation;
            result.UpdatedAt = currentDate;
            result.UpdatedBy = UserEmail;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> DeleteTicket(int id)
        {
            var delete = await GetTicket(id);
            _context.Remove(delete);
            int row = await _context.SaveChangesAsync();
            return row > 0;
        }
    }
}

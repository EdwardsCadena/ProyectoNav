using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Api.Response;
using Proyecto.Core.DTOs;
using Proyecto.Core.Entities;
using Proyecto.Core.Interfaces;

namespace Proyecto.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _TicketRepository;
        private readonly IMapper _mapper;

        public TicketController(ITicketRepository TicketRepository, IMapper mapper)
        {
            _TicketRepository = TicketRepository;
            _mapper = mapper;
        }

        [HttpGet]

        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            try
            {
                // Obtiene los tickets desde el repositorio
                var Tickets = await _TicketRepository.GetTickets();

                // Mapea los tickets a TicketDTOs
                var TicketsDto = _mapper.Map<IEnumerable<TicketDTOs>>(Tickets);

                // Devuelve los tickets
                return Ok(TicketsDto);
            }
            catch (Exception ex)
            {
                // Registra la excepción si es necesario y devuelve un mensaje de error significativo
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicket(int id)
        {
            try
            {
                // Obtiene el ticket específico desde el repositorio
                var Ticket = await _TicketRepository.GetTicket(id);
                // Si el Ticket es null, entonces el id no existe en la base de datos
                if (Ticket == null)
                {
                    return NotFound("El ticket con id " + id + " no se encontró.");
                }

                // Mapea el ticket a TicketDTOs
                var TicketDto = _mapper.Map<TicketDTOs>(Ticket);

                // Devuelve el ticket
                return Ok(TicketDto);
            }
            catch (Exception ex)
            {
                // Registra la excepción si es necesario y devuelve un mensaje de error significativo
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostTicket(TicketDTOs ticketDto)
        {
            try
            {
                // Mapea el TicketDTOs a Ticket
                var Ticket = _mapper.Map<Ticket>(ticketDto);

                // Obtiene el correo electrónico del usuario autenticado
                var userEmail = User.Identity.Name;

                // Inserta el ticket en el repositorio
                await _TicketRepository.InsertTicket(Ticket, userEmail);

                // Prepara la respuesta
                var updatedto = new ApiResponse<TicketDTOs>(ticketDto);

                // Devuelve la respuesta
                return Ok(updatedto);
            }
            catch (Exception ex)
            {
                // Registra la excepción si es necesario y devuelve un mensaje de error significativo
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, TicketDTOs TicketDto)
        {
            try
            {
                // Mapea el TicketDTOs a Ticket
                var Ticket = _mapper.Map<Ticket>(TicketDto);
                // Si el Ticket es null, entonces el id no existe en la base de datos
                if (Ticket == null)
                {
                    return NotFound("El ticket con id " + id + " no se encontró.");
                }

                // Asigna el id al ticket
                Ticket.Id = id;

                // Obtiene el correo electrónico del usuario autenticado
                var userEmail = User.Identity.Name;

                // Actualiza el ticket en el repositorio
                var Update = await _TicketRepository.UpdateTicket(Ticket, userEmail);

                // Prepara la respuesta
                var updatedto = new ApiResponse<bool>(Update);

                // Devuelve la respuesta
                return Ok(updatedto);
            }
            catch (Exception ex)
            {
                // Registra la excepción si es necesario y devuelve un mensaje de error significativo
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            try
            {
                // Elimina el ticket en el repositorio
                var result = await _TicketRepository.DeleteTicket(id);
                if (result == null)
                {
                    return NotFound("El ticket con id " + id + " no se encontró.");
                }
                // Prepara la respuesta
                var delete = new ApiResponse<bool>(result);

                // Devuelve la respuesta
                return Ok(delete);
            }
            catch (Exception ex)
            {
                // Registra la excepción si es necesario y devuelve un mensaje de error significativo
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        private IActionResult CheckTicketExists(Ticket ticket, int id)
        {
            // Si el Ticket es null, entonces el id no existe en la base de datos
            if (ticket == null)
            {
                return NotFound($"El ticket con id {id} no se encontró.");
            }

            return null;
        }
    }
}

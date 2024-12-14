using Domain.Models;
using Infrastructore.ApiResponse;
using System.Net;
namespace Infrastructore.Interfaces;



public interface ITicketService
{
    public Response<List<Ticket>> GetTickets();
    public Response<bool> AddTicket(Ticket ticket);
    public Response<bool> UpdateTicket(Ticket ticket);
    public Response<bool> DeleteTicket(int id);
    public Response<Ticket> GetTicket(int id);
}
using Domain.Models;
using Infrastructore.ApiResponse;
using System.Net;
namespace Infrastructore.Interfaces;



public interface ITicketLocationService
{
    public Response<bool> AddTicketLocation(TicketLocation TicketLocation);
    public Response<bool> DeleteTicketLocation(int id);
    public Response<TicketLocation> GetTicketLocation(int id);
}
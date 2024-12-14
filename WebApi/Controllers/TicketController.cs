using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Services;
using Infrastructore.Interfaces;
using Infrastructore.ApiResponse;
using System.Net;
using System.Security.Cryptography;

namespace TicketManagment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketController(ITicketService ticketService):ControllerBase
{
    [HttpGet]
    public Response<List<Ticket>> GetResponses()
    {
        var response=ticketService.GetTickets();
        return response;
    }
    [HttpPost]
    public Response<bool> AddTicket(Ticket ticket)
    {
        var response=ticketService.AddTicket(ticket);
        return response;
    }
    [HttpPut]
    public Response<bool> Update(Ticket ticket)
    {
        var response=ticketService.UpdateTicket(ticket);
        return response;
    }
    [HttpDelete]
    public Response<bool> Delete(int id)
    {
        var response=ticketService.DeleteTicket(id);
        return response;
    }
    [HttpGet ("get-by-id")]
    public Response<Ticket> GetById(int id)
    {
        var response=ticketService.GetTicket(id);
        return response;
    }
}
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Services;
using Infrastructore.Interfaces;
using Infrastructore.ApiResponse;
using System.Net;
using System.Security.Cryptography;

namespace TicketLocationManagment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketLocationController(ITicketLocationService ticketLocationService):ControllerBase
{

    [HttpPost]
    public Response<bool> AddTicketLocation(TicketLocation TicketLocation)
    {
        var response=ticketLocationService.AddTicketLocation(TicketLocation);
        return response;
    }
    [HttpDelete]
    public Response<bool> Delete(int id)
    {
        var response=ticketLocationService.DeleteTicketLocation(id);
        return response;
    }
    [HttpGet ("get-by-id")]
    public Response<TicketLocation> GetById(int id)
    {
        var response=ticketLocationService.GetTicketLocation(id);
        return response;
    }
}
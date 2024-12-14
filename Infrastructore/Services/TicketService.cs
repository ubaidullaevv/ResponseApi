using Dapper;
using Domain.Models;
using Infrastructore.ApiResponse;
using Infrastructore.Datacontext;
using Infrastructore.Interfaces;
using System.Net;
namespace Services;


public class TicketService(DapperContext _context) : ITicketService
{
    public Response<bool> AddTicket(Ticket ticket)
    {
        using var context=_context.Connection();
        string cmd="insert into tickets(type,title,price,eventDateTime)values(@Type,@Title,@Price,@EventDateTime)";
        var res=context.Execute(cmd,ticket);
        if(ticket==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public Response<bool> DeleteTicket(int id)
    {
         using var context=_context.Connection();
        string cmd="delete from tickets where ticketid=@TicketId";
        var res=context.Execute(cmd,new {TicketId=id});
        if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public Response<Ticket> GetTicket(int id)
    {
        using var context=_context.Connection();
         string cmd="select * from tickets where ticketid=@TicketId";
        var res=context.Query<Ticket>(cmd,new {TicketId=id}).FirstOrDefault();
        if(res==null)
        {
            return new Response<Ticket>(HttpStatusCode.InternalServerError,"Client Eror!");
        }
        return new Response<Ticket>(res);
    }

    public Response<List<Ticket>> GetTickets()
    {
        using var context=_context.Connection();
        string cmd="select * from tickets";
        var res=context.Query<Ticket>(cmd).ToList();
        if(res==null)
        {
            return new Response<List<Ticket>>(HttpStatusCode.InternalServerError,"Client Eror!");
        }
        return new Response<List<Ticket>>(res);
    }

    public Response<bool> UpdateTicket(Ticket ticket)
    {
        using var context=_context.Connection();
        string cmd="update  tickets set ticketid=@TicketId, type=@Type,title=@Title,price=@Price,eventDateTime=@EventDateTime";
        var res=context.Execute(cmd,ticket);
        if(ticket==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }
}

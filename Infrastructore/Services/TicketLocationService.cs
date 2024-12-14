using Dapper;
using Domain.Models;
using Infrastructore.ApiResponse;
using Infrastructore.Datacontext;
using Infrastructore.Interfaces;
using System.Net;
using Npgsql;
namespace Services;


public class TicketLocationService(DapperContext _context) : ITicketLocationService
{
    public Response<bool> AddTicketLocation(TicketLocation ticketLocation)
    {
        using var context=_context.Connection();
        string cmd="insert into TicketLocations(ticketid,locationid)values(@TicketId,@LocationId)";
        var res=context.Execute(cmd,ticketLocation);
        if(ticketLocation==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public Response<bool> DeleteTicketLocation(int id)
    {
         using var context=_context.Connection();
        string cmd="delete from TicketLocations where ticketLocationId=@TicketLocationId";
        var res=context.Execute(cmd,new {TicketLocationId=id});
        if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public Response<TicketLocation> GetTicketLocation(int id)
    {
        using var context=_context.Connection();
         string cmd="select * from TicketLocations where ticketLocationId=@TicketLocationId";
        var res=context.Query<TicketLocation>(cmd,new {TicketLocationId=id}).FirstOrDefault();
        if(res==null)
        {
            return new Response<TicketLocation>(HttpStatusCode.InternalServerError,"Client Eror!");
        }
        return new Response<TicketLocation>(res);
    }


}

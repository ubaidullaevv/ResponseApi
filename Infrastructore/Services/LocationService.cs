using Dapper;
using Domain.Models;
using Infrastructore.ApiResponse;
using Infrastructore.Datacontext;
using Infrastructore.Interfaces;
using System.Net;
namespace Services;


public class LocationService(DapperContext _context) : ILocationService
{
    public Response<bool> AddLocation(Location location)
    {
        using var context=_context.Connection();
        string cmd="insert into Locations(city,address,locationtype)values(@City,@Address,@LocationType)";
        var res=context.Execute(cmd,location);
        if(location==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public Response<bool> DeleteLocation(int id)
    {
         using var context=_context.Connection();
        string cmd="delete from Locations where locationid=@LocationId";
        var res=context.Execute(cmd,new {LocationId=id});
        if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public Response<Location> GetLocation(int id)
    {
        using var context=_context.Connection();
         string cmd="select * from Locations where locationid=@LocationId";
        var res=context.Query<Location>(cmd,new {LocationId=id}).FirstOrDefault();
        if(res==null)
        {
            return new Response<Location>(HttpStatusCode.InternalServerError,"Client Eror!");
        }
        return new Response<Location>(res);
    }

    public Response<List<Location>> GetLocations()
    {
        using var context=_context.Connection();
        string cmd="select * from Locations";
        var res=context.Query<Location>(cmd).ToList();
        if(res==null)
        {
            return new Response<List<Location>>(HttpStatusCode.InternalServerError,"Client Eror!");
        }
        return new Response<List<Location>>(res);
    }

    public Response<bool> UpdateLocation(Location location)
    {
        using var context=_context.Connection();
        string cmd="update  Locations set locationid=@LocationId , city=@City,address=@Address,locationtype=@LocationType";
        var res=context.Execute(cmd,location);
        if(location==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }
}

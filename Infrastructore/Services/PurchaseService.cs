using Dapper;
using Domain.Models;
using Infrastructore.ApiResponse;
using Infrastructore.Datacontext;
using Infrastructore.Interfaces;
using System.Net;
using Npgsql;
namespace Services;


public class PurchaseService(DapperContext _context) : IPurchaseService
{
    public Response<bool> AddPurchase(Purchase purchase)
    {
        using var context=_context.Connection();
        string cmd="insert into Purchases(ticketid,customerid,purchaseDateTime,quantity,totalprice)values(@TicketId,@CustomerId,@PurchaseDateTime,@Quantity,@TotalPrice)";
        var res=context.Execute(cmd,purchase);
        if(purchase==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public Response<Purchase> GetPurchase(int id)
    {
        using var context=_context.Connection();
         string cmd="select * from Purchases where purchaseId=@PurchaseId";
        var res=context.Query<Purchase>(cmd,new {PurchaseId=id}).FirstOrDefault();
        if(res==null)
        {
            return new Response<Purchase>(HttpStatusCode.InternalServerError,"Client Eror!");
        }
        return new Response<Purchase>(res);
    }

    public Response<List<Purchase>> GetPurchases()
    {
        using var context=_context.Connection();
        string cmd="select * from Purchases";
        var res=context.Query<Purchase>(cmd).ToList();
        if(res==null)
        {
            return new Response<List<Purchase>>(HttpStatusCode.InternalServerError,"Client Eror!");
        }
        return new Response<List<Purchase>>(res);
    }

}

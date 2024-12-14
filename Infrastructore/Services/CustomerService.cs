using Dapper;
using Domain.Models;
using Infrastructore.ApiResponse;
using Infrastructore.Datacontext;
using Infrastructore.Interfaces;
using System.Net;
namespace Services;


public class CustomerService(DapperContext _context) : ICustomerService
{
    public Response<bool> AddCustomer(Customer customer)
    {
        using var context=_context.Connection();
        string cmd="insert into Customers(fullname,email,phone)values(@FullName,@Email,@Phone)";
        var res=context.Execute(cmd,customer);
        if(customer==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public Response<bool> DeleteCustomer(int id)
    {
         using var context=_context.Connection();
        string cmd="delete from Customers where customerid=@CustomerId";
        var res=context.Execute(cmd,new {CustomerId=id});
        if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public Response<Customer> GetCustomer(int id)
    {
        using var context=_context.Connection();
         string cmd="select * from Customers where customerid=@CustomerId";
        var res=context.Query<Customer>(cmd,new {CustomerId=id}).FirstOrDefault();
        if(res==null)
        {
            return new Response<Customer>(HttpStatusCode.InternalServerError,"Client Eror!");
        }
        return new Response<Customer>(res);
    }

    public Response<List<Customer>> GetCustomers()
    {
        using var context=_context.Connection();
        string cmd="select * from Customers";
        var res=context.Query<Customer>(cmd).ToList();
        if(res==null)
        {
            return new Response<List<Customer>>(HttpStatusCode.InternalServerError,"Client Eror!");
        }
        return new Response<List<Customer>>(res);
    }

    public Response<bool> UpdateCustomer(Customer customer)
    {
        using var context=_context.Connection();
        string cmd="update  Customers set customerid=@CustomerId fullname=@FullName,email=@Email,phone=@Phone";
        var res=context.Execute(cmd,customer);
        if(customer==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }
}

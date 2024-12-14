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
public class CustomerController(ICustomerService customerService):ControllerBase
{
    [HttpGet]
    public Response<List<Customer>> GetResponses()
    {
        var response=customerService.GetCustomers();
        return response;
    }
    [HttpPost]
    public Response<bool> AddCustomer(Customer Customer)
    {
        var response=customerService.AddCustomer(Customer);
        return response;
    }
    [HttpPut]
    public Response<bool> Update(Customer Customer)
    {
        var response=customerService.UpdateCustomer(Customer);
        return response;
    }
    [HttpDelete]
    public Response<bool> Delete(int id)
    {
        var response=customerService.DeleteCustomer(id);
        return response;
    }
    [HttpGet ("get-by-id")]
    public Response<Customer> GetById(int id)
    {
        var response=customerService.GetCustomer(id);
        return response;
    }
}
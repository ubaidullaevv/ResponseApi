using Domain.Models;
using Infrastructore.ApiResponse;
using System.Net;
namespace Infrastructore.Interfaces;



public interface ICustomerService
{
    public Response<List<Customer>> GetCustomers();
    public Response<bool> AddCustomer(Customer customer);
    public Response<bool> UpdateCustomer(Customer customer);
    public Response<bool> DeleteCustomer(int id);
    public Response<Customer> GetCustomer(int id);
}
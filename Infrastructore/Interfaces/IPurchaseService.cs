using Domain.Models;
using Infrastructore.ApiResponse;
using System.Net;
namespace Infrastructore.Interfaces;



public interface IPurchaseService
{
    public Response<List<Purchase>> GetPurchases();
    public Response<bool> AddPurchase(Purchase purchase);
    public Response<Purchase> GetPurchase(int id);
}
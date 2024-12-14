using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Services;
using Infrastructore.Interfaces;
using Infrastructore.ApiResponse;
using System.Net;
using System.Security.Cryptography;

namespace PurchaseManagment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PurchaseController(IPurchaseService purchaseService):ControllerBase
{
    [HttpGet]
    public Response<List<Purchase>> GetResponses()
    {
        var response=purchaseService.GetPurchases();
        return response;
    }
    [HttpPost]
    public Response<bool> AddPurchase(Purchase Purchase)
    {
        var response=purchaseService.AddPurchase(Purchase);
        return response;
    }

    [HttpGet ("get-by-id")]
    public Response<Purchase> GetById(int id)
    {
        var response=purchaseService.GetPurchase(id);
        return response;
    }
}
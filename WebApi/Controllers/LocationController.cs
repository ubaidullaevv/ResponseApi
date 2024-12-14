using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Services;
using Infrastructore.Interfaces;
using Infrastructore.ApiResponse;
using System.Net;
using System.Security.Cryptography;

namespace LocationManagment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController(ILocationService locationService):ControllerBase
{
    [HttpGet]
    public Response<List<Location>> GetResponses()
    {
        var response=locationService.GetLocations();
        return response;
    }
    [HttpPost]
    public Response<bool> AddLocation(Location Location)
    {
        var response=locationService.AddLocation(Location);
        return response;
    }
    [HttpPut]
    public Response<bool> Update(Location Location)
    {
        var response=locationService.UpdateLocation(Location);
        return response;
    }
    [HttpDelete]
    public Response<bool> Delete(int id)
    {
        var response=locationService.DeleteLocation(id);
        return response;
    }
    [HttpGet ("get-by-id")]
    public Response<Location> GetById(int id)
    {
        var response=locationService.GetLocation(id);
        return response;
    }
}
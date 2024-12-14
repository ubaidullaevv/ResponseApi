using Domain.Models;
using Infrastructore.ApiResponse;
using System.Net;
namespace Infrastructore.Interfaces;



public interface ILocationService
{
    public Response<List<Location>> GetLocations();
    public Response<bool> AddLocation(Location location);
    public Response<bool> UpdateLocation(Location location);
    public Response<bool> DeleteLocation(int id);
    public Response<Location> GetLocation(int id);
}
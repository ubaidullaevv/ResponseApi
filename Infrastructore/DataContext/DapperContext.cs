using Npgsql;
namespace Infrastructore.Datacontext;

public class DapperContext
{
    private readonly string connectionString=$"Server=Localhost; Port=5432; Database=TicketManagmentDB; User Id=postgres; password=12345;";
    
    public NpgsqlConnection Connection()
    {
     return new NpgsqlConnection(connectionString);
    }
}

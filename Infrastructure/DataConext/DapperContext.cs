namespace Dappercontext;
using Npgsql;
using Dapper;

public class DapperContext
{
    readonly string connectionString = "Server=127.0.0.1;Port=5432;Database=product_db;User Id=postgres;Password=12345;";
    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(connectionString);
    }
}
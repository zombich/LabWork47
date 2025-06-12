using Microsoft.Data.Sqlite;
using System.Data;

namespace Database.Database
{
    public class SqliteFactory(string connectionString) : IDatabaseFactory
    {
        public IDbConnection CreateConnection() => new SqliteConnection(connectionString);
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Database
{
    public interface IDatabaseFactory
    {
        IDbConnection CreateConnection();
    }
    public class MsSqlFactory(string connectionString) : IDatabaseFactory
    {
        public IDbConnection CreateConnection() => new SqlConnection(connectionString);
    }

    public class SqliteFactory(string connectionString) : IDatabaseFactory
    {
        public IDbConnection CreateConnection() => new SqliteConnection(connectionString);
    }
}

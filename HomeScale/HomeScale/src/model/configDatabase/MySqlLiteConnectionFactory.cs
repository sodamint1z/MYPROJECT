using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaknampoScale.src.model.configDatabase
{
    public class MySqlLiteConnectionFactory : IDbConnectionFactory
    {
        public DbConnection CreateConnection(string connectionString)
        {
            return new SQLiteConnection(connectionString);
        }
    }
}

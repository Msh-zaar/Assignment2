using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessWithSql.Repositories
{
    public class ConnectionStringHelper
    {
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = @"DESKTOP-8LK9FE7\SQLEXPRESS";
            connectionStringBuilder.InitialCatalog = "Chinook";
            connectionStringBuilder.IntegratedSecurity = true;
            connectionStringBuilder.TrustServerCertificate = true;
            return connectionStringBuilder.ConnectionString;
        }
    }
}

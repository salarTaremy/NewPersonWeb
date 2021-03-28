using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Authentication
{
    public interface IDbConnection
    {
        public SqlConnection GetConnection { get; }
    }


    public class DbConnection : IDbConnection
    {
        IConfiguration Configuration;

        public DbConnection(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public SqlConnection GetConnection
        {
            get
            {
                var connectionString = Configuration.GetConnectionString("Person");
                return new SqlConnection(connectionString);
            }
        }
    }
}

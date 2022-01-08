using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using UploadScorm.Core.Common;

namespace UploadScorm.infra.Common
{
    public class DBContext : IDBContext
    {
        private DbConnection connection;
        private readonly IConfiguration configuration;
        public DBContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public DbConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new SqlConnection(configuration["ConnectionStrings:DBConnectionString"]);
                    connection.Open();
                }
                else if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                return connection;
            }
        }
    }
}
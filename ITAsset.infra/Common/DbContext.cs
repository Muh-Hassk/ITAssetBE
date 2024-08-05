using ITAsset.core.ICommon;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace ITAsset.infra.Common
{
    public class DbContext : IDbContext
    {
        private DbConnection _connection;
        private readonly IConfiguration _configuration;

        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbConnection Connection
        {
            get
            {
                // if there's no connection 
                if (_connection == null)
                {
                    
                    _connection = new MySqlConnection(_configuration["ConnectionStrings:DBConnectionString"]);
                    _connection.Open();
                }
                // if there's a connection but it's not open
                else if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }
    }
}
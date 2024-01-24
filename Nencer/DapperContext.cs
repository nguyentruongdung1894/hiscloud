﻿using System.Data.SqlClient;
using System.Data;
using MySqlConnector;

namespace Nencer
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default");
        }
        public IDbConnection CreateConnection()
            => new MySqlConnection(_connectionString);
    }
}

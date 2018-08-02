using Microsoft.Extensions.Options;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Arshid.Configuration
{
    public class ConnectionManager
    {
        private IOptions<ArshidConfiguration> _options;

        public ConnectionManager(IOptions<ArshidConfiguration> options)
        {
            string connectionString = options.Value.PgSqlServerConnectionString;
            _options = options;
        }

        public IDbConnection getNew()
        {
            string connectionString = _options.Value.PgSqlServerConnectionString;
            var connection = new NpgsqlConnection(connectionString);
            return connection;
        }
    }
}

using Dapper;
using MySql.Data.MySqlClient;
using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Query
{
    public class SubscribeQueries : ISubscribeQueries
    {
        private string _connectionString = string.Empty;

        public SubscribeQueries(string connectionString)
        {
            _connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<IEnumerable<Subscribe>> GetAllSubscribes()
        {
            // using (var connection = new SqlConnection(_connectionString))
            //mysql
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Subscribe>(
                    // @"SELECT t.[Id] FROM [CargoXDb].[dbo].[Faces] t"
                    @"SELECT * FROM cargox.subscribes t"
                );
                return result;
            }
        }
    }
}

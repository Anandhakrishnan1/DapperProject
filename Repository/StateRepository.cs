using Dapper;
using DapperProject.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperProject.Repository
{
    public class StateRepository
    {
        private readonly IConfiguration _configuration;
        public StateRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<IEnumerable<State>> GetAllStates()
        {
            using (var connection = CreateConnection())
            {
                var sql = "SELECT * FROM States";
                return await connection.QueryAsync<State>(sql);
            }
        }

        public async Task InsertState(State state)
        {
            using (var connection = CreateConnection())
            {
                var sql = "INSERT INTO States (StateName) VALUES (@StateName)";
                await connection.ExecuteAsync(sql, new { state.StateName });
            }
        }
    }
}

using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Creditcard.DataContract;
using System.Data.SqlClient;
using Dapper;

namespace Creditcard.Repository
{
    public class CreditcardRepository : ICreditcardRepository
    {
        private readonly string _connString;

        public CreditcardRepository(IConfiguration config)
        {
            _connString = config.GetConnectionString("Default");
        }

        public async Task<IEnumerable<Card>> GetCards(string userId)
        {
            var sql = @"SELECT 
                          [Name]
                          ,[CardNumber]
                          ,[CVC]
                          ,[ExpiryDate]
                      FROM [Customer].[Card]
                      WHERE UserId=@userId";
            using var connection = new SqlConnection(_connString);
            var cards = await connection.QueryAsync<Card>(sql, new { userId });
            return cards;
        }
    }
}

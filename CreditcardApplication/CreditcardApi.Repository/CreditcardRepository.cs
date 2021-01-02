using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreditcardApi.DataContract;
using System.Data.SqlClient;
using Dapper;
using System;

namespace CreditcardApi.Repository
{
    public class CreditcardRepository : ICreditcardRepository
    {
        private readonly string _connString;

        public CreditcardRepository(IConfiguration config)
        {
            _connString = config.GetConnectionString("Default");
        }

        public async Task<Card> GetCard(string userId, string cardId)
        {
            var sql = @"SELECT TOP 1
                          [Name]
                          ,[CardNumber]
                          ,[CVC]
                          ,[ExpiryDate]
                      FROM [Customer].[Card]
                      WHERE UserId=@userId and Id=@cardId";
            try
            {
                using var connection = new SqlConnection(_connString);
                var card = await connection.QueryFirstAsync<Card>(sql, new { userId, cardId });
                return card;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

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
            try
            {
                using var connection = new SqlConnection(_connString);
                var cards = await connection.QueryAsync<Card>(sql, new { userId });
                return cards;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task SaveCard(Card card)
        {
            var sql = @"INSERT INTO [Customer].[Card]
                               ([UserId]
                               ,[Name]
                               ,[CardNumber]
                               ,[CVC]
                               ,[ExpiryDate])
                         VALUES
                               (@UserId
                               ,@Name
                               ,@CardNumber
                               ,@CVC
                               ,@ExpiryDate)";
            try
            {
                using var connection = new SqlConnection(_connString);
                await connection.ExecuteAsync(sql, card);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }
    }
}

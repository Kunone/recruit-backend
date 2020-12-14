using CreditcardApi.DataContract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditcardApi.Service
{
    public interface ICreditcardService
    {
        Task<IEnumerable<Card>> GetAllCards(string userId);
        Task<Card> GetCard(string userId, string cardId);
        Task SaveCard(string userId, Card card);
    }
}
using Creditcard.DataContract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Creditcard.Service
{
    public interface ICreditcardService
    {
        Task<IEnumerable<Card>> GetAllCards(string userId);
        Task<Card> GetCard(string userId, string cardId);
        Task SaveCard(string userId, Card card);
    }
}
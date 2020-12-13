using Creditcard.DataContract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Creditcard.Repository
{
    public interface ICreditcardRepository
    {
        Task<Card> GetCard(string userId, string cardId);
        Task<IEnumerable<Card>> GetCards(string userId);
        Task SaveCard(Card card);
    }
}
using Creditcard.DataContract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Creditcard.Repository
{
    public interface ICreditcardRepository
    {
        Task<IEnumerable<Card>> GetCards(string userId);
    }
}
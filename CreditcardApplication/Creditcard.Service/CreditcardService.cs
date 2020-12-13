using Creditcard.DataContract;
using Creditcard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creditcard.Service
{
    public class CreditcardService : ICreditcardService
    {
        private readonly ICreditcardRepository _creditcardRepository;

        public CreditcardService(ICreditcardRepository creditcardRepository)
        {
            _creditcardRepository = creditcardRepository;
        }

        public async Task<IEnumerable<Card>> GetAllCards(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("missing user id");
            }

            var cards = await _creditcardRepository.GetCards(userId);
            return cards;
        }

        public async Task SaveCard(string userId, Card card)
        {
            card.UserId = new Guid(userId);
            await _creditcardRepository.SaveCard(card);
        }
    }
}

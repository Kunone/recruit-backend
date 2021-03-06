﻿using CreditcardApi.DataContract;
using CreditcardApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditcardApi.Service
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

        public async Task<Card> GetCard(string userId, string cardId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("missing user id");
            }
            if (string.IsNullOrEmpty(cardId))
            {
                throw new ArgumentNullException("missing card id");
            }

            var card = await _creditcardRepository.GetCard(userId, cardId);
            return card;
        }
    }
}

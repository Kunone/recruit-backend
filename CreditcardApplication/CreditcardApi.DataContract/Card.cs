using System;
using System.Collections.Generic;
using System.Text;

namespace CreditcardApi.DataContract
{
    public class Card
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string CardNumber { get; set; } // to be encrypted
        public string CVC { get; set; } // to be encrypted
        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

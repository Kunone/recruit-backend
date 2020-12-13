using System;
using System.Collections.Generic;
using System.Text;

namespace Creditcard.DataContract
{
    public class Creditcard
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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creditcard.DataContract
{
    public class CardViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"\d{16}", ErrorMessage = "Please input a valid number")]
        public string CardNumber { get; set; }

        [Required]
        [RegularExpression(@"\d{3}", ErrorMessage = "Please input a valid number")]
        public string CVC { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }
    }
}

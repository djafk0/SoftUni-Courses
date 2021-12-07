using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportCardJsonDto
    {
        [Required]
        [RegularExpression("[0-9]{4} [0-9]{4} [0-9]{4}")]
        public string Number { get; set; }

        [Required]
        [RegularExpression("[0-9]{3}")]
        public string Cvc { get; set; }

        [Required]
        public CardType? Type { get; set; }

        //    "Number": "1111 1111 1111 1111",
        //    "CVC": "111",
        //    "Type": "Debit"
    }
}

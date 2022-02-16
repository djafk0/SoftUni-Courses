using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static SMS.Data.DataConstants;

namespace SMS.Models
{
    public class Cart
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public User User { get; set; }

        public List<Product> Products { get; init; } = new List<Product>();
    }
}

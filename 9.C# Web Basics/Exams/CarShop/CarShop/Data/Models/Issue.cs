using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarShop.Data.DataConstants;

namespace CarShop.Data.Models
{
    public class Issue
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; init; }

        public bool IsFixed { get; set; }

        [Required]
        [MaxLength(IdMaxLength)]
        public string CarId { get; init; }

        [ForeignKey(nameof(CarId))]
        public Car Car { get; init; }
    }
}

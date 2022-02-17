using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarShop.Data.DataConstants;

namespace CarShop.Data.Models
{
    public class Car
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Model { get; init; }

        public int Year { get; init; }

        [Required]
        public string PictureUrl { get; init; }

        [Required]
        [MaxLength(PlateNumberMaxLength)]
        public string PlateNumber { get; init; }

        [Required]
        [MaxLength(IdMaxLength)]
        public string OwnerId { get; init; }

        [ForeignKey(nameof(OwnerId))]
        public User Owner { get; init; }

        public IEnumerable<Issue> Issues { get; init; } = new List<Issue>();
    }
}

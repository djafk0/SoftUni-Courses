using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportGamesJsonDto
    {
        [Required]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }

        public IEnumerable<string> Tags { get; set; }
        //    "Name": "Invalid",
        //"Price": -5,
        //"ReleaseDate": "2013-07-09",
        //"Developer": "Valid Dev",
        //"Genre": "Valid Genre",
        //"Tags": ["Valid Tag"]

    }
}

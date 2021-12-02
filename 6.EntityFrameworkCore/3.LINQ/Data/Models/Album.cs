using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public Album()
        {
            Songs = new HashSet<Song>();
        }
        
        [Key]
        public int Id { get; set; }

        [StringLength(40)]
        [Required]
        public string Name { get; set; }
        
        [Required]
        public DateTime ReleaseDate { get; set; }

        public decimal Price
            => this.Songs.Sum(s => s.Price);

        [ForeignKey(nameof(Producer))]
        public int? ProducerId { get; set; }
        public virtual Producer Producer { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}

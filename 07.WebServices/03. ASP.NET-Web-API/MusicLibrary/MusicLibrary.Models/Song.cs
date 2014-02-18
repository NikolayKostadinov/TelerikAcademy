namespace MusicLibrary.Models
{
    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

    public class Song
    {
        [Key]
        public int SongId { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        public int Year { get; set; }

        [MaxLength(30)]
        public string Gender { get; set; }

        [ForeignKey("Artist")]
        public int ArtistId { get; set; }

        public Artist Artist { get; set; }
    }
}

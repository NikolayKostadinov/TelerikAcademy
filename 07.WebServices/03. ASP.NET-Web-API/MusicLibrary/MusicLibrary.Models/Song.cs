namespace MusicLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    [Table("Songs")]
    [DataContract(IsReference = true)]
    public class Song
    {
        [Key]
        [DataMember]
        public int SongId { get; set; }

        [Required]
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public int Year { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [ForeignKey("Artist")]
        [DataMember]
        public int ArtistId { get; set; }

        [DataMember]
        public virtual Artist Artist { get; set; }

        [ForeignKey("Album")]
        [DataMember]
        public int AlbumId { get; set; }

        [DataMember]
        public virtual Album Album { get; set; }
    }
}

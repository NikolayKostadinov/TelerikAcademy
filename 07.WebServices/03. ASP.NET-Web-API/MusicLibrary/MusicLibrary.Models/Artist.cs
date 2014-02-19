namespace MusicLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("Artists")]
    [DataContract(IsReference = true)]
    public class Artist
    {
        public Artist() 
        {
            this.Albums = new HashSet<Album>();
        }

        [Key]
        [DataMember]
        public int ArtistId { get; set; }

        [Required]
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}

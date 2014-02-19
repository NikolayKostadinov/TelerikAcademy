namespace MusicLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("Albums")]
    [DataContract(IsReference = true)]
    public class Album
    {
        public Album()
        {
            this.Artists = new HashSet<Artist>();
            this.Songs = new HashSet<Song>();
        }

        [Key]
        [DataMember]
        public int AlbumId { get; set; }

        [Required]
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public virtual DateTime? ReleaseDate { get; set; }

        [DataMember]
        public string Producer { get; set; }

        [DataMember]
        public virtual ICollection<Artist> Artists { get; set; }

        [DataMember]
        public virtual ICollection<Song> Songs { get; set; }
    }
}

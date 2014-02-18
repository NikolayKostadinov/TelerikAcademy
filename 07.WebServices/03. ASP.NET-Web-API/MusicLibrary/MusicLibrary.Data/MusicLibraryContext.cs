namespace MusicLibrary.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using MusicLibrary.Models;

    public class MusicLibraryContext : DbContext
    {
        public MusicLibraryContext()
            : base("MusicLibrary") 
        { 
        }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Song> Songs { get; set; }

    }
}

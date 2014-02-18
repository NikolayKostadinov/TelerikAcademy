namespace MusicLibrary.ConsoleTest
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using MusicLibrary.Data;
    using MusicLibrary.Data.Migrations;
    using MusicLibrary.Models;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicLibraryContext, Configuration>());
            var myArtist = new Artist()
            {
                Country = "USA",
                DateOfBirth = new DateTime(1997, 12, 5),
                Name = "Some Idiot"
            };


            var mySong = new Song()
                    {
                        Gender = "Rock",
                        Title = "A Song Of An Idiot",
                        Year = 2014,
                    };

            Album myAlbum = new Album()
            {
                Producer = "Some fucking Idiot",
                Title = "Songs Of An Idiot",
                Year = 2014,
            };

            myArtist.Songs.Add(mySong);
            myAlbum.Artists.Add(myArtist);
            myAlbum.Songs.Add(mySong);
            myArtist.Albums.Add(myAlbum);

            using (MusicLibraryContext context = new MusicLibraryContext())
            {
                context.Songs.Add(mySong);
                context.Artists.Add(myArtist);
                context.Albums.Add(myAlbum);
                context.SaveChanges();
            }
        }
    }
}

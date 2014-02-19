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
            
            //Song mySong = new Song()
            //        {
            //            Gender = "Rock",
            //            Title = "A Song Of An Idiot",
            //            Year = 2014,
            //        };

            //Artist myArtist = new Artist()
            //{
            //    Country = "USA",
            //    DateOfBirth = new DateTime(1997, 12, 5),
            //    Name = "Some Idiot"
            //};
            
            //Album myAlbum = new Album()
            //{
            //    Producer = "Some fucking Idiot",
            //    Title = "Songs Of An Idiot",
            //    Year = 2014,
            //};

            //myArtist.Songs.Add(mySong);
            //myAlbum.Artists.Add(myArtist);
            //myAlbum.Songs.Add(mySong);
            //myArtist.Albums.Add(myAlbum);

            using (MusicLibraryContext context = new MusicLibraryContext())
            {
                var songs = context.Songs.Include(s=>s.Artist);

                foreach (Song song in songs.AsEnumerable())
                {
                    Console.WriteLine("{0,20}|{1,20}|{2,20}", song.Artist.Name, song.SongId, song.Title);
                }
            }
        }
    }
}

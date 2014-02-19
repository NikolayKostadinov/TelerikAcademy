namespace MusicLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MusicLibrary.Models;

    public sealed class Configuration : DbMigrationsConfiguration<MusicLibraryContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MusicLibraryContext context)
        {
            var songs = new Song[] {
                new Song { Gender = "Metal", Title = "01.Kill 'Em All", Year = 1984 },
                new Song { Gender = "Metal", Title = "02.Kill 'Em All", Year = 1984 },
                new Song { Gender = "Metal", Title = "03.Kill 'Em All", Year = 1984 },
                new Song { Gender = "Metal", Title = "04.Kill 'Em All", Year = 1984 },
                new Song { Gender = "Metal", Title = "05.Kill 'Em All", Year = 1984 },
                new Song { Gender = "Metal", Title = "06.Kill 'Em All", Year = 1984 },
                new Song { Gender = "Metal", Title = "07.Kill 'Em All", Year = 1984 },
                new Song { Gender = "Metal", Title = "08.Kill 'Em All", Year = 1984 },
                new Song { Gender = "Metal", Title = "01.And Jostice For All", Year = 1988 },
                new Song { Gender = "Metal", Title = "02.And Jostice For All", Year = 1988 },
                new Song { Gender = "Metal", Title = "03.And Jostice For All", Year = 1988 },
                new Song { Gender = "Metal", Title = "04.And Jostice For All", Year = 1988 },
                new Song { Gender = "Metal", Title = "05.And Jostice For All", Year = 1988 },
                new Song { Gender = "Metal", Title = "06.And Jostice For All", Year = 1988 },
                new Song { Gender = "Metal", Title = "07.And Jostice For All", Year = 1988 },
                new Song { Gender = "Metal", Title = "08.And Jostice For All", Year = 1988 }
            };

            var artist = new Artist()
            {
                Country = "USA",
                Name = "Metallica",
                BirthDate = new DateTime(1982, 03, 12)
            };

            var album1 = new Album()
            {
                Title = "Kill 'Em All",
                ReleaseDate = new DateTime(1988,10,3),
                Producer = "Black Shed",
            };

            var album2 = new Album()
            {
                Title = "...And Justice For All",
                ReleaseDate = new DateTime(1988,10,3),
                Producer = "Bob Rock",
            };

            album1.Artists.Add(artist);
            album2.Artists.Add(artist);

            foreach (var song in songs)
            {
                if (song.Year == 1984)
                {
                    album1.Songs.Add(song);
                }
                else
                {
                    album2.Songs.Add(song);
                }
            }

            artist.Albums.Add(album1);
            artist.Albums.Add(album2);


            context.Songs.AddOrUpdate(songs);
            context.Artists.AddOrUpdate(artist);
            context.Albums.AddOrUpdate(album1);
            context.Albums.AddOrUpdate(album2);
        }
    }
}

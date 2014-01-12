using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XDocumentXmlConsoleWriteSongsList
{
    class XDocumentXmlConsoleWriteSongsList
    {
        static void Main()
        {
            XDocument xmlDoc = XDocument.Load("../../catalog.xml");
            var albums =
              from xmlAlbum in xmlDoc.Descendants("album")
              select new { 
                  Name = xmlAlbum.Element("name").Value,
                  Artist = xmlAlbum.Element("artist").Value,
                  Songs = from xmlSongs in xmlAlbum.Descendants("song")
                  select new
                  {
                      Title = xmlSongs.Element("title").Value,
                      Duration = xmlSongs.Element("duration").Value
                  }
              };
           
            Console.WriteLine("Found {0} albums:", albums.Count());
            int albumNumber = 0;
            foreach (var album in albums)
            {
                int songsNumber = 0;

                Console.WriteLine();
                Console.WriteLine(" {0}. {1} (by {2})", ++albumNumber, album.Name, album.Artist);

                foreach (var song in album.Songs)
                {
                    Console.WriteLine("     {0}. {1} - {2}", ++songsNumber, song.Title, song.Duration);
                }
            }
        }
    }
}

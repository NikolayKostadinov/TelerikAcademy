using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XPathExtractor
{
    class XPathExtractor
    {
        static void Main()
        {
            Dictionary<string,int> countOfAlbumsByArtists = new Dictionary<string,int>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../catalog.xml");
            Console.WriteLine("Document was loaded!\n");
            string xPathQuery = "/catalog/album";
            XmlNodeList albumList = xmlDoc.SelectNodes(xPathQuery);

            foreach (XmlNode album in albumList)
            {
                XmlNode artist = album.SelectSingleNode("artist");
                string artistName = artist.InnerText;

                if (countOfAlbumsByArtists.ContainsKey(artistName))
                {
                    countOfAlbumsByArtists[artistName]++;
                }
                else
                {
                    countOfAlbumsByArtists.Add(artistName, 1);
                }      
            }

            foreach (var artist in countOfAlbumsByArtists)
            {
                Console.WriteLine("Artist: {0} has {1} albums incatalog.", artist.Key, artist.Value);
            }
        }
    }
}

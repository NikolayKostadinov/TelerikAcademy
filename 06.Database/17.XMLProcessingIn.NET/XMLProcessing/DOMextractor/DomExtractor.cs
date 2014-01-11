/* Write program that extracts all different artists which are found in the catalog.xml. 
 * For each author you should print the number of albums in the catalogue. 
 * Use the DOM parser and a hash-table.
 */
namespace DOMextractor
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    class DomExtractor
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> countOfAlbumsByArtists = new Dictionary<string, int>();
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");
            Console.WriteLine("Loaded XML document:");
            Console.WriteLine();

            XmlNode rootNode = doc.DocumentElement;

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                string key = node["artist"].InnerText;

                if (countOfAlbumsByArtists.ContainsKey(key))
                {
                    countOfAlbumsByArtists[key]++;
                }
                else
                {
                    countOfAlbumsByArtists.Add(key, 1);
                }
            }

            foreach (var artist in countOfAlbumsByArtists)
            {
                Console.WriteLine("Artist: {0} has {1} albums incatalog.", artist.Key, artist.Value);
            }
        }
    }
}

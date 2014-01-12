namespace ExtractAlbumsFromCatalog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    //TODO: Write a program, which (using XmlReader and XmlWriter) reads the file catalog.xml and creates the file album.xml, 
    //      in which stores in appropriate way the names of all albums and their authors.

    class ExtractAlbumsFromCatalog
    {
        private class Album
        {
            public string Name { get; set; }

            public string Autor { get; set; }
        }

        static void Main()
        {
            string inputFileName = "../../catalog.xml";
            string outputFileName = "../../album.xml";

            using (XmlReader reader = XmlReader.Create(inputFileName))
            {
                Album album = new Album();
                IList<Album> albums = new List<Album>();

                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                       (reader.Name == "name"))
                    {
                        album.Name = reader.ReadElementString();
                    }

                    if ((reader.NodeType == XmlNodeType.Element) &&
                       (reader.Name == "artist"))
                    {
                        album.Autor = reader.ReadElementString();
                        AddAlbumToList(albums, album);
                    }
                }

                WriteExtractedToXml(outputFileName, albums);
            }
        }

        private static void WriteExtractedToXml(string outputFileName, IList<Album> albums)
        {
            using (XmlTextWriter writer = new XmlTextWriter(outputFileName, Encoding.GetEncoding("windows-1251")))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();

                writer.WriteStartElement("albums");

                foreach (var album in albums)
                {
                    writer.WriteStartElement("album");
                    writer.WriteElementString("name", album.Name);
                    writer.WriteElementString("address", album.Autor);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
        }

        private static void AddAlbumToList(IList<Album> albums, Album album)
        {
            albums.Add(new Album() { Name = album.Name, Autor = album.Autor });
        }
    }
}

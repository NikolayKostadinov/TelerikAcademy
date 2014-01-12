namespace SaxParsingXmlConsoleWriteSongsList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    class SaxParsingXmlConsoleWriteSongsList
    {
        static void Main()
        {
            using (XmlReader reader = XmlReader.Create("../../catalog.xml"))
            {
                int albumNumber = 0;
                int songNumber = 0;

                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                    (reader.Name == "name"))
                    {
                        Console.WriteLine();
                        Console.Write("{0}. {1} - artist ", ++albumNumber, reader.ReadElementString());
                        songNumber = 0;
                    }

                    if ((reader.NodeType == XmlNodeType.Element) &&
                    (reader.Name == "artist"))
                    {
                        Console.WriteLine (reader.ReadElementString());
                    }

                    if ((reader.NodeType == XmlNodeType.Element) &&
                    (reader.Name == "title")) 
                    {
                        Console.Write("   {0}. {1}", ++songNumber,reader.ReadElementString());
                    }
                    
                    if ((reader.NodeType == XmlNodeType.Element) &&
                    (reader.Name == "duration")) 
                    {
                        Console.WriteLine(" - {0}", reader.ReadElementString());
                    }
                }
            }
        }
    }
}

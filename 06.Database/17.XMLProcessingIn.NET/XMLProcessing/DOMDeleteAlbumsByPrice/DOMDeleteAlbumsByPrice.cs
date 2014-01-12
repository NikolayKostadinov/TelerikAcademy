using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DOMDeleteAlbumsByPrice
{
    class DOMDeleteAlbumsByPrice
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalog.xml");
            Console.WriteLine("Loaded XML document:");
            Console.WriteLine();

            XmlNode rootNode = doc.DocumentElement;
            string culture = rootNode.Attributes["culture"].Value;
            CultureInfo cultireInfo =
                CultureInfo.GetCultureInfo(culture);
            List<XmlNode> nodesToDelete = new List<XmlNode>();
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                decimal price = decimal.Parse(node["price"].InnerText, cultireInfo);
                if (price == 20.00m)
                {
                    Console.WriteLine("Album {0} of artist {1} with price {2} will be removed.", node["name"].InnerText, node["artist"].InnerText, node["price"].InnerText);
                    nodesToDelete.Add(node);
                }
            }

            foreach (var node in nodesToDelete) 
            {
                rootNode.RemoveChild(node); 
            }

            doc.Save("../../catalox1.xml");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ImageGalery.ViewModels
{
    public class DataPersister
    {
        /// <summary>
        /// Gets the ambums from XML.
        /// </summary>
        /// <param name="albumsPath">The albums path.</param>
        /// <returns></returns>
        public static IEnumerable<AlbumViewModel> GetAmbumsFromXml(string xmlPath)
        {
            XDocument doc = XDocument.Load(xmlPath);
            var root = doc.Root;
            var albums = root.Elements("album")
                .AsQueryable()
                .Select(AlbumViewModel.FromXElement);
            return albums;
        }
    }
}

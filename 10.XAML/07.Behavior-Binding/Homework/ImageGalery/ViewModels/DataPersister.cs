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

        internal static void AddAlbum(string documenPath, AlbumViewModel album)
        {
            var root = XDocument.Load(documenPath).Root;
            root.Add(new XElement("album",
                new XElement("name", album.Name),
                new XElement("images", GetImages(album))));
            root.Document.Save(documenPath);
        }
  
        /// <summary>
        /// Gets the images.
        /// </summary>
        /// <param name="album">The album.</param>
        /// <returns></returns>
        private static object[] GetImages(AlbumViewModel album)
        {
            var images = new List<XElement>();
            foreach (var image in album.Images)
            {
                images.Add(new XElement("image", new XElement("title", image.Title), new XElement("source", image.ImageSource)));
            }
            return images.ToArray();
        }
    }
}
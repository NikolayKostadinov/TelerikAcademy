using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ImageViewerMVVM.Models
{
    class ModelImageSource : INotifyPropertyChanged
    {
        private ObservableCollection<string> imageSources;

        public ModelImageSource()
        {
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ObservableCollection<string> ImageSources
        {
            get
            {
                if (this.imageSources == null)
                {
                    ReloadImageSources();
                }
                return this.imageSources;
            }
        }

        private IEnumerable<string> GetSources()
        {
            IEnumerable<string> sources = GetSourceFromXMLFile();
            return sources;
        }

        private IEnumerable<string> GetSourceFromXMLFile()
        {
            var xmlDocRoot = GetImagesXMLRoot();
            IEnumerable<string> sources = xmlDocRoot.
                Descendants("image").
                Select(xmlElement => xmlElement.Attribute("source").Value).ToList();
            return sources;
        }

        private XElement GetImagesXMLRoot()
        {
            XDocument imageXMLDoc = XDocument.Load("..\\..\\ImageResources\\ImageSources.xml");
            var xmlDocRoot = imageXMLDoc.Root;
            return xmlDocRoot;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void AddNewFiles(string[] fileNames)
        {
            var xmlDocRoot = GetImagesXMLRoot();
            foreach (var filename in fileNames)
            {
                XElement newElement = new XElement("image");
                newElement.SetAttributeValue("source", filename);
                xmlDocRoot.Add(newElement);
            }
            SaveImagesXMLDoc(xmlDocRoot);
        }

        private void SaveImagesXMLDoc(XElement xmlDocRoot)
        {
            xmlDocRoot.Save("..\\..\\ImageResources\\ImageSources.xml");
            ReloadImageSources();
        }

        private void ReloadImageSources()
        {
            imageSources = new ObservableCollection<string>( GetSources());
            OnPropertyChanged("ImageSources");
        }

        internal void Delete(string fileToDelete)
        {
            var root = GetImagesXMLRoot();
            var elementToDelete = root.Descendants("image").FirstOrDefault(element => element.Attribute("source").Value == fileToDelete);
            elementToDelete.Remove();
            SaveImagesXMLDoc(root);
        }
    }
}
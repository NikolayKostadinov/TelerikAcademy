using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Linq;
using ImageGalery.Commands;

namespace ImageGalery.ViewModels
{
    public class AlbumViewModel:BaseViewModel
    {
        private string name;
        private ICommand previouseCommand;
        private ICommand nextCommand;
        private ObservableCollection<ImageViewModel> images;
       
        public string Name
        {
            get 
            { 
                return this.name; 
            }
            set 
            { 
                this.name = value;
                this.OnPropertyChanged("Name");
            }
        }

        public IEnumerable<ImageViewModel> Images
        {
            get 
            {
                if (this.images == null)
                {
                    this.images = new ObservableCollection<ImageViewModel>();
                }
                return images; 
            }
            set 
            {
                if (this.images == null)
                {
                    this.images = new ObservableCollection<ImageViewModel>();
                }
                this.images.Clear();
                foreach (var image in value)
                {
                    this.images.Add(image);
                }
            }
        }

        public ICommand Previons 
        {
            get 
            {
                if (this.previouseCommand == null)
                {
                    this.previouseCommand = new RelayCommand(this.HandlePreviouseCommand);
                }
                return this.previouseCommand;
            }
        }
  
        public ICommand Next 
        {
            get 
            {
                if (this.nextCommand == null)
                {
                    this.nextCommand = new RelayCommand(this.HandleNextCommand);
                }
                return this.nextCommand;
            }
        }

        private void HandlePreviouseCommand(object obj)
        {
            var citiesViewCollection = this.GetDefaultView(this.images);

            citiesViewCollection.MoveCurrentToPrevious();
            if (citiesViewCollection.IsCurrentBeforeFirst)
            {
                citiesViewCollection.MoveCurrentToLast();
            }
        }
          
        private void HandleNextCommand(object obj)
        {
            var citiesViewCollection = this.GetDefaultView(this.images);

            citiesViewCollection.MoveCurrentToNext();
            if (citiesViewCollection.IsCurrentAfterLast)
            {
                citiesViewCollection.MoveCurrentToFirst();
            }
        }

        private ICollectionView GetDefaultView(ObservableCollection<ImageViewModel> collection)
        {
            return CollectionViewSource.GetDefaultView(collection);
        }

        public static Expression<Func<XElement,AlbumViewModel>>FromXElement
        {
            get
            {
                return element =>
                    new AlbumViewModel()
                    {
                        Name = element.Element("name").Value,
                        Images = GetImagesFromXml(element.Element("images")),                        
                    };
            }
        }
  
        /// <summary>
        /// Gets the images from XML.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        private static IEnumerable<ImageViewModel> GetImagesFromXml(XElement element)
        {
            var images = element.Elements("image")
                            .AsQueryable()
                            .Select(ImageViewModel.FromXElement);
            return images;
        }
    }
}

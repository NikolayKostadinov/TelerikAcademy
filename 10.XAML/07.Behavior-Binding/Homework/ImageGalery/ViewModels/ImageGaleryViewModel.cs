using ImageGalery.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ImageGalery.ViewModels
{
    public class ImageGaleryViewModel:BaseViewModel
    {
        private string albumsPath = "..\\..\\galery.xml"; 

        private ObservableCollection<AlbumViewModel> albums;
        private ImageViewModel newImage;
        private AlbumViewModel newAlbum;
        private ICommand addImageCommand;
        private ICommand addAlbumCommand;
        private IList<ImageViewModel> newImages = new List<ImageViewModel>();

        public ImageViewModel NewImage
        {
            get { return this.newImage; }
            set
            {
                this.newImage = value;
                this.OnPropertyChanged("NewImage");
            }
        }

        public AlbumViewModel NewAlbum
        {
            get { return this.newAlbum; }
            set
            {
                this.newAlbum = value;
                this.OnPropertyChanged("NewAlbum");
            }
        }

        public ImageGaleryViewModel() 
        {
            this.Albums = DataPersister.GetAmbumsFromXml(albumsPath);
        }

        public ICommand AddImage 
        { 
            get 
            {
                if (this.addImageCommand == null)
                {
                    this.addImageCommand = new RelayCommand(this.HandleAddImageCommand);
                }
                return this.addImageCommand;
            } 
        }
  
        /// <summary>
        /// Handles the add image command.
        /// </summary>
        /// <param name="obj">The obj.</param>
        private void HandleAddImageCommand(object obj)
        {
            if (this.newAlbum == null)
            {
                this.newAlbum = new AlbumViewModel();
            }
            this.newImages.Add(this.NewImage);
            this.NewAlbum.Images = this.newImages;
        }

        public ICommand AddAlbum
        {
            get
            {
                if (this.addAlbumCommand == null)
                {
                    this.addAlbumCommand = new RelayCommand(this.HandleAddAlbumCommand);
                }
                return this.addAlbumCommand;
            }
        }
  
        /// <summary>
        /// Handles the add album command.
        /// </summary>
        /// <param name="obj">The obj.</param>
        private void HandleAddAlbumCommand(object obj)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public IEnumerable<AlbumViewModel> Albums 
        {
            get 
            {
                if (this.albums == null)
                {
                    this.albums = new ObservableCollection<AlbumViewModel>();
                }
                return this.albums;
            }
            set 
            {
                if (this.albums == null)
                {
                    this.albums = new ObservableCollection<AlbumViewModel>();
                }
                this.albums.Clear();
                foreach (var album in value)
                {
                    this.albums.Add(album);
                }
            }
        }
    }
}

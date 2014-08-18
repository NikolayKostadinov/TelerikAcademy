using ImageGalery.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;

namespace ImageGalery.ViewModels
{
    public class ImageGaleryViewModel : BaseViewModel
    {
        private string albumsPath = "..\\..\\galery.xml";

        private ObservableCollection<AlbumViewModel> albums;
        private ImageViewModel newImage;
        private AlbumViewModel newAlbum;
        private ICommand addImageCommand;
        private ICommand addAlbumCommand;
        private ICommand fileOpenCommand;

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

        public ImageViewModel NewImage
        {
            get
            {
                if (this.newImage == null)
                {
                    this.newImage = new ImageViewModel();
                }
                return this.newImage;
            }
            set
            {
                this.newImage = value;
                this.OnPropertyChanged("NewImage");
            }
        }

        public AlbumViewModel NewAlbum
        {
            get
            {
                if (this.newAlbum == null)
                {
                    this.newAlbum = new AlbumViewModel();
                }
                return this.newAlbum;
            }
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

        public ICommand FileOpen 
        { 
            get 
            {
                if (this.fileOpenCommand == null) 
                {
                    this.fileOpenCommand = new RelayCommand(this.HandleFileOpenCommand);
                }
                return this.fileOpenCommand;
            } 
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
        /// Handles the file open command.
        /// </summary>
        /// <param name="obj">The obj.</param>
        private void HandleFileOpenCommand(object obj)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.ShowDialog();
            if (!fileDialog.FileNames.Any())
            {
                return;
            }
            else if (fileDialog.FileNames.Length > 1)
            {
                IList<ImageViewModel> currentImages = new List<ImageViewModel>();
                foreach (var image in this.NewAlbum.Images)
                {
                    currentImages.Add(image);
                }
                foreach (var fileName in fileDialog.FileNames)
                {
                    currentImages.Add(new ImageViewModel(fileName));
                }

                this.NewAlbum.Images = currentImages;
                
            }
            else 
            {
                this.NewImage = new ImageViewModel(){ImageSource = fileDialog.FileName};
            }
            OnPropertyChanged("ImageSource");
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
            IList<ImageViewModel> currentImmages = new List<ImageViewModel>();
            foreach (var image in this.NewAlbum.Images)
            {
                currentImmages.Add(image);
            }
            currentImmages.Add(this.NewImage);
            this.NewAlbum.Images = currentImmages;
            this.NewImage = new ImageViewModel();
            this.OnPropertyChanged("NewAlbum");
        }

        /// <summary>
        /// Handles the add album command.
        /// </summary>
        /// <param name="obj">The obj.</param>
        private void HandleAddAlbumCommand(object obj)
        {
            IList<AlbumViewModel> currentAlbums = new List<AlbumViewModel>();
            foreach (var album in this.Albums)
            {
                currentAlbums.Add(album);
            }
            currentAlbums.Add(this.NewAlbum);
            this.Albums = currentAlbums;
            DataPersister.AddAlbum(this.albumsPath, this.NewAlbum);
            this.NewAlbum = new AlbumViewModel();
        }

    }
}

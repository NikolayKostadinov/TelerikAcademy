using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageViewerMVVM.Models;
using System.Windows;
using System.Windows.Input;
using ImageViewerMVVM.Commands;
using System.Windows.Forms;
using System.Windows.Data;

namespace ImageViewerMVVM.ViewModels
{
    class ViewModelImageSource : ViewModelBase
    {
        private ModelImageSource model;
        private int currentImageIndex;
        private ICommand nextCommand;
        private ICommand previousCommand;
        private ICommand addCommand;
        private ICommand deleteCommand;

        public ViewModelImageSource()
        {
            model = new ModelImageSource();
            currentImageIndex = 0;

            var view = CollectionViewSource.GetDefaultView(this.ImageSources);
            view.CurrentChanged += new EventHandler(view_CurrentChanged);
        }

        void view_CurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("CurrentImageSource");
        }

        public ICommand Add
        {
            get
            {
                if (this.addCommand == null)
                {
                    this.addCommand = new RelayCommand(
                        () =>
                        {
                            OpenFileDialog fileDialog = new OpenFileDialog();
                            fileDialog.Multiselect = true;
                            fileDialog.ShowDialog();
                            if (!fileDialog.FileNames.Any())
                            {
                                return;
                            }

                            this.model.AddNewFiles(fileDialog.FileNames);

                            OnPropertyChanged("ImageSources");
                        });
                }
                return addCommand;
            }
        }

        public ICommand Delete
        {
            get 
            {
                if (this.deleteCommand == null)
                {
                    this.deleteCommand = new RelayCommand(
                        () =>
                        {
                            var view = CollectionViewSource.GetDefaultView(this.ImageSources);
                            var fileToDelete = view.CurrentItem.ToString();
                            this.model.Delete(fileToDelete);

                            this.OnPropertyChanged("ImageSources");
                            this.OnPropertyChanged("CurrentImageSource");
                        });
                }
                return deleteCommand;
            }
        }

        public ICommand Next
        {
            get
            {
                if (this.nextCommand == null)
                {
                    this.nextCommand = new RelayCommand(
                        () =>
                        {
                            int imagesCount = ImageSources.Count();

                            this.currentImageIndex++;
                            if (currentImageIndex >= imagesCount)
                            {
                                this.currentImageIndex %= imagesCount;
                            }
                            this.OnPropertyChanged("CurrentImageSource");
                        });
                }
                return nextCommand;
            }
        }

        public ICommand Previous
        {
            get
            {
                if (this.previousCommand == null)
                {
                    this.previousCommand = new RelayCommand(
                        () =>
                        {
                            this.currentImageIndex--;
                            if (currentImageIndex < 0)
                            {
                                int imagesCount = ImageSources.Count();
                                this.currentImageIndex += imagesCount;
                            }
                            this.OnPropertyChanged("CurrentImageSource");
                        });
                }
                return previousCommand;
            }
        }

        public IEnumerable<string> ImageSources
        {
            get
            {
                return this.model.ImageSources;
            }
        }

        public string CurrentImageSource
        {
            get
            {
                return this.ImageSources.ElementAt(currentImageIndex);
            }
        }
    }
}
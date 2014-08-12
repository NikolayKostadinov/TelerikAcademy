using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ImageGalery.ViewModels
{
    public class ImageViewModel : BaseViewModel
    {
        private string title;
        private string imageSounce;

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
                this.OnPropertyChanged("Title");
            }
        }

        public string ImageSource
        {
            get
            {
                return this.imageSounce;
            }
            set
            {
                this.imageSounce = value;
                this.OnPropertyChanged("ImageSource");
            }
        }

        public static Expression<Func<XElement, ImageViewModel>> FromXElement
        {
            get
            {
                return element => new ImageViewModel()
                {
                    Title = element.Element("title").Value,
                    ImageSource = element.Element("source").Value,
                };
            }
        }
    }
}
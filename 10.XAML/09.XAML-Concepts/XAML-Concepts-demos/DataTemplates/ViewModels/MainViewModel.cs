using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTemplates.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<PhoneViewModel> Phones { get; set; }

        public MainViewModel()
        {
            this.Phones = new ObservableCollection<PhoneViewModel>();
            this.Phones.Add(new PhoneViewModel()
            {
                Vendor = "Samsung",
                Model = "Galaxy S4"
            });
            this.Phones.Add(new PhoneViewModel()
            {
                Vendor = "iPhone",
                Model = "4"
            });
            this.Phones.Add(new PhoneViewModel()
            {
                Vendor = "HTC",
                Model = "One"
            });
            this.Phones.Add(new PhoneViewModel()
            {
                Vendor = "Nokia",
                Model = "Lumia 920"
            });
        }

    }
}

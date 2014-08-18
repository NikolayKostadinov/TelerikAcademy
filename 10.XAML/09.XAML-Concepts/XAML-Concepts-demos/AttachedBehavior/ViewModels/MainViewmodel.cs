using AttachedBehavior.Behavior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AttachedBehavior.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string message;

        public ICommand Click { get; set; }

        public ICommand WindowLoaded { get; set; }

        public MainViewModel()
        {
            this.Click = new RelayCommand(this.HandleClick);
            this.WindowLoaded = new RelayCommand(this.HandleWindowLoaded);
        }

        private void HandleWindowLoaded(object obj)
        {
            this.Message = "Window loaded\n";
        }

        private void HandleClick(object obj)
        {
            this.Message += "Clicked at " + DateTime.Now + "\n";
        }

        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
                this.OnPropertyChanged("Message");
            }
        }
    }
}

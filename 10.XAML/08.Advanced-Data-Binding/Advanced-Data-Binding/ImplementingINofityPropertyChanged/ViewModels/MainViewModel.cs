using System.Windows.Threading;
using ImplementingINofityPropertyChanged.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ImplementingINofityPropertyChanged.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string successMessage;
        private string errorMessage;
        DispatcherTimer timer;

        private ICommand raiseSuccessCommand;
        private ICommand raiseErrorCommand;

        public string SuccessMessage
        {
            get
            {
                return this.successMessage;
            }
            set
            {
                this.successMessage = value;
                this.OnPropertyChanged("SuccessMessage");
            }
        }

        public string ErrorMessage
        {
            get
            {
                return this.errorMessage;
            }
            set
            {
                this.errorMessage = value;
                this.OnPropertyChanged("ErrorMessage");
            }
        }

        public ICommand RaiseSuccess
        {
            get
            {
                if (this.raiseSuccessCommand == null)
                {
                    this.raiseSuccessCommand = new RelayCommand(this.HandleSuccessCommand);
                }
                return this.raiseSuccessCommand;
            }
        }

        public ICommand RaiseError
        {
            get
            {
                if (this.raiseErrorCommand == null)
                {
                    this.raiseErrorCommand = new RelayCommand(this.HandleErrorCommand);
                }
                return this.raiseErrorCommand;
            }
        }

        private void HandleSuccessCommand(object obj)
        {
            this.SuccessMessage = "Success!";
            timer = new DispatcherTimer();
            timer.Tick += (snd, args) =>
            {
                this.SuccessMessage = "";
                timer.Stop();
            };
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Start();
        }

        private void HandleErrorCommand(object obj)
        {
            this.ErrorMessage = "Error!";
            timer = new DispatcherTimer();
            timer.Tick += (snd, args) =>
            {
                this.ErrorMessage = "";
                timer.Stop();
            };
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Start();
        }
    }
}
using Behavior_Binding.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Behavior_Binding.ViewModels
{
    public class StoreViewModel : INotifyPropertyChanged
    {
        private ICommand prevCommand;
        private ICommand nextCommand;

        private void HandleExecutePrevCommand(object obj)
        {
            var view = CollectionViewSource.GetDefaultView(this.Phones);
            view.MoveCurrentToPrevious();
            if (view.IsCurrentBeforeFirst)
            {
                view.MoveCurrentToLast();
            }
        }
        private void HandleExecuteNextCommand(object obj)
        {
            var view = CollectionViewSource.GetDefaultView(this.Phones);
            view.MoveCurrentToNext();
            if (view.IsCurrentAfterLast)
            {
                view.MoveCurrentToFirst();
            }
        }

        public IEnumerable<PhoneViewModel> Phones { get; set; }

        public PhoneViewModel CurrentPhone
        {
            get
            {
                var view = CollectionViewSource.GetDefaultView(this.Phones);
                return view.CurrentItem as PhoneViewModel;
            }
        }

        public ICommand Prev
        {
            get
            {
                if (this.prevCommand == null)
                {
                    this.prevCommand = new RelayCommand(
                        this.HandleExecutePrevCommand);
                }
                return this.prevCommand;
            }
        }

        public ICommand Next
        {
            get
            {
                if (this.nextCommand == null)
                {
                    this.nextCommand = new RelayCommand(
                        this.HandleExecuteNextCommand);
                }
                return this.nextCommand;
            }
        }

        public ICommand Load { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public StoreViewModel()
        {
            this.Phones = DataPersister.GetPhonesFromXml("..\\..\\phones.xml");
            //this.OnPropertyChanged("CurrentPhone");

            var view = CollectionViewSource.GetDefaultView(this.Phones);
            view.CurrentChanged += (snd, args) =>
            {
                this.OnPropertyChanged("CurrentPhone");
            };
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
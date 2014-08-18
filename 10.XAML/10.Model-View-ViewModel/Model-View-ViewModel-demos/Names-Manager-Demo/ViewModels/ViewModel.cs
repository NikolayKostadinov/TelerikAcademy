using System.ComponentModel;
using Names_Manager_Demo.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Names_Manager_Demo.ViewModels
{
    class ViewModel : INotifyPropertyChanged
    {
        private Model model;

        public ViewModel()
        {
            this.model = new Model();
        }

        public ObservableCollection<string> Names
        {
            get
            {
                return this.model.Names;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        internal void AddNewName(string newName)
        {
            this.model.AddNewName(newName);
            OnPropertyChanged("Names");
        }

        internal void DeleteName(object nameToDelete)
        {
            string name = nameToDelete.ToString();
            if (!string.IsNullOrEmpty(name))
            {
                this.model.DeleteName(name);
                OnPropertyChanged("Names");
            }
        }
    }
}
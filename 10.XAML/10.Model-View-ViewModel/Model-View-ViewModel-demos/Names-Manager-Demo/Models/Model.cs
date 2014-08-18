using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Names_Manager_Demo.Models
{
    class Model
    {
        private ObservableCollection<string> names;

        public Model()
        {
        }

        public ObservableCollection<string> Names
        {
            get
            {
                if (this.names == null)
                {
                    this.names = new ObservableCollection<string>();
                }
                return this.names;
            }
        }

        internal void AddNewName(string newName)
        {
            this.names.Add(newName);
        }

        internal void DeleteName(string name)
        {
            if (this.names.Contains(name))
            {
                this.names.Remove(name);
            }
        }
    }
}
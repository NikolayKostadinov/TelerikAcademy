using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Linq;
using PhonesStore.Commands;
using System.Windows.Threading;

namespace PhonesStore.ViewModels
{
    public class PhonesStoreViewModel : ViewModelBase
    {
        private ObservableCollection<PhoneViewModel> phonesViewModels;

        private ObservableCollection<OperatingSystemViewModel> operationalSystems;

        private ICommand addNewCommand;

        private string successMessage;

        private string errorMessage;
        private PhoneViewModel newPhoneViewModel;

        public string PhonesStoreDocumentPath { get; set; }

        public PhonesStoreViewModel()
        {
            this.PhonesStoreDocumentPath = "..\\..\\phones.xml";
            this.newPhoneViewModel = new PhoneViewModel();
        }

        public ICommand AddNew
        {
            get
            {
                if (this.addNewCommand == null)
                {
                    this.addNewCommand = new RelayCommand(this.HandleAddNewCommand);
                }
                return this.addNewCommand;
            }
        }

        public PhoneViewModel NewPhone
        {
            get
            {
                return this.newPhoneViewModel;
            }
            set
            {
                this.newPhoneViewModel = value;
                this.OnPropertyChanged("NewPhone");
            }
        }

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

        public IEnumerable<PhoneViewModel> Phones
        {
            get
            {
                if (this.phonesViewModels == null)
                {
                    this.Phones = DataPersister.GetPhones(PhonesStoreDocumentPath);
                }
                return phonesViewModels;
            }
            set
            {
                if (this.phonesViewModels == null)
                {
                    this.phonesViewModels = new ObservableCollection<PhoneViewModel>();
                }
                this.phonesViewModels.Clear();
                foreach (var item in value)
                {
                    this.phonesViewModels.Add(item);
                }
            }
        }

        public IEnumerable<OperatingSystemViewModel> OperationalSystems
        {
            get
            {
                if (this.operationalSystems == null)
                {
                    this.OperationalSystems = DataPersister.GetAllOperationalSystems(this.PhonesStoreDocumentPath);
                }
                return this.operationalSystems;
            }
            set
            {
                if (this.operationalSystems == null)
                {
                    this.operationalSystems = new ObservableCollection<OperatingSystemViewModel>();
                }
                this.operationalSystems.Clear();
                foreach (var item in value)
                {
                    this.operationalSystems.Add(item);
                }
            }
        }

        private void HandleAddNewCommand(object obj)
        {
            try
            {
                DataPersister.AddPhone(this.PhonesStoreDocumentPath, this.NewPhone);
                this.Phones = DataPersister.GetPhones(this.PhonesStoreDocumentPath);
                this.SetSuccessMessage(string.Format("{0} {1} successfully added!", this.NewPhone.Vendor, this.NewPhone.Model));
                this.NewPhone = new PhoneViewModel();
            }
            catch (Exception ex)
            {
                this.SetErrorMessage(string.Format("Adding {0} {1} failed with exception {2} ", this.NewPhone.Vendor, this.NewPhone.Model, ex.Message));
            }
        }

        private void SetSuccessMessage(string text)
        {
            this.SuccessMessage = text;
            var timer = new DispatcherTimer();
            timer.Tick += (snd, args) =>
            {
                this.SuccessMessage = "";
                timer.Stop();
            };
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Start();
        }

        private void SetErrorMessage(string text)
        {
            this.SuccessMessage = text;
            var timer = new DispatcherTimer();
            timer.Tick += (snd, args) =>
            {
                this.SuccessMessage = "";
                timer.Stop();
            };
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Start();
        }
    }
}
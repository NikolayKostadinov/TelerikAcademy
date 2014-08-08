using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Linq;

namespace PhonesStore.ViewModels
{
    public class PhonesStoreViewModel
    {
        public string PhonesStoreDocumentPath { get; set; }

        public PhonesStoreViewModel()
        {
            this.PhonesStoreDocumentPath = "..\\..\\..\\PhonesStore.ViewModels\\phones.xml";
        }

        private IEnumerable<PhoneViewModel> phonesViewModels;

        public IEnumerable<PhoneViewModel> Phones
        {
            get
            {
                if (this.phonesViewModels == null)
                {
                    this.phonesViewModels = DataPersister.GetAll(PhonesStoreDocumentPath);
                }
                return phonesViewModels;
            }
        }

        public void Next()
        {
            var phonesCollectionView = this.GetDefaultView(this.phonesViewModels);
            phonesCollectionView.MoveCurrentToNext();
            if (phonesCollectionView.IsCurrentAfterLast)
            {
                phonesCollectionView.MoveCurrentToLast();
            }
        }

        public void Prev()
        {
            var phonesCollectionView = this.GetDefaultView(this.phonesViewModels);
            phonesCollectionView.MoveCurrentToPrevious();
            if (phonesCollectionView.IsCurrentBeforeFirst)
            {
                phonesCollectionView.MoveCurrentToFirst();
            }
        }

        public void Sort()
        {
            var phonesCollectionView = this.GetDefaultView(this.phonesViewModels);
            if (phonesCollectionView.SortDescriptions.Count == 0)
            {
                phonesCollectionView.SortDescriptions.Add(new SortDescription("Vendor", ListSortDirection.Ascending));
                phonesCollectionView.SortDescriptions.Add(new SortDescription("Model", ListSortDirection.Ascending));
            }
            else
            {
                phonesCollectionView.SortDescriptions.Clear();
            }
        }

        private ICollectionView GetDefaultView<T>(IEnumerable<T> collection)
        {
            return CollectionViewSource.GetDefaultView(collection);
        }

        public void Filter(string filterText)
        {
            var phonesCollectionView = this.GetDefaultView(this.phonesViewModels);
            if (filterText == string.Empty)
            {
                phonesCollectionView.Filter = null;
            }
            else
            {
                var filterTextToLower = filterText.ToLower();
                phonesCollectionView.Filter = (item) =>
                {
                    var phoneItem = item as PhoneViewModel;
                    if (phoneItem == null)
                    {
                        return false;
                    }
                    return phoneItem.Vendor.ToLower().Contains(filterTextToLower) ||
                           phoneItem.Model.ToLower().Contains(filterTextToLower) ||
                           phoneItem.Year.ToString().Contains(filterTextToLower) ||
                           phoneItem.OS.Name.ToLower().Contains(filterTextToLower) ||
                           phoneItem.OS.Version.ToLower().Contains(filterTextToLower) ||
                           phoneItem.OS.Manufacturer.ToLower().Contains(filterTextToLower);
                };
            }
        }

        public void GroupByYear()
        {
            var view = this.GetDefaultView(this.phonesViewModels);
            if (view.GroupDescriptions.Count == 0)
            {
                view.GroupDescriptions.Add(new PropertyGroupDescription("Year"));
            }
            else
            {
                view.GroupDescriptions.Clear();
            }
        
        }
    }
}
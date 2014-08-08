using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchicalDataBinding.ViewModels
{
    public class MainViewModel
    {
        private const string VendorsDocumentPath = "..\\..\\phones.xml";
        private IEnumerable<VendorViewModel> vendors;

        public IEnumerable<VendorViewModel> Vendors
        {
            get
            {
                if (this.vendors == null)
                {
                    this.vendors = DataPersister.GetVendorsWithPhones(VendorsDocumentPath);
                }

                return this.vendors;
            }
        }
    }
}

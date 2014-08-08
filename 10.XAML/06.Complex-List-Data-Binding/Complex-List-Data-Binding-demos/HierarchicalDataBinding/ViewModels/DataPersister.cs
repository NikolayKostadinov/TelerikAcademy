using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HierarchicalDataBinding.ViewModels
{
    internal class DataPersister
    {
        public static IEnumerable<VendorViewModel> GetVendorsWithPhones(string documentPath)
        {
            XElement vendorsRoot = XDocument.Load(documentPath).Root;
            var vendorElements = vendorsRoot.Elements("vendor");
            var vendorViewModels = vendorElements.AsQueryable()
                                                 .Select(VendorViewModel.FromXElement);

            return vendorViewModels;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Xml.Linq;
using System.Linq;

namespace HierarchicalDataBinding.ViewModels
{
    public class VendorViewModel
    {
        public string Name { get; set; }

        public IEnumerable<PhoneViewModel> Phones { get; set; }

        internal static Expression<Func<XElement, VendorViewModel>> FromXElement
        {
            get
            {
                return x =>
                new VendorViewModel()
                {
                    Name = x.Element("name").Value,
                    Phones = x.Element("phones")
                              .Elements("phone")
                              .AsQueryable()
                              .Select(PhoneViewModel.FromXElement)
                };
            }
        }
    }
}
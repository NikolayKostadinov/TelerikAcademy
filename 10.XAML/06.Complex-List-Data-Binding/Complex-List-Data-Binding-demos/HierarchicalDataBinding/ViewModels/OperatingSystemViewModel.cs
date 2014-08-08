using System;
using System.Linq.Expressions;
using System.Xml.Linq;
namespace HierarchicalDataBinding.ViewModels
{
    public class OperatingSystemViewModel
    {
        public string Name { get; set; }

        public string Version { get; set; }

        internal static Expression<Func<XElement,OperatingSystemViewModel>> FromXElement
        {
            get
            {
                return x => new OperatingSystemViewModel()
                {
                    Name = x.Element("name").Value,
                    Version = x.Element("version").Value
                };
            }
        }
    }
}
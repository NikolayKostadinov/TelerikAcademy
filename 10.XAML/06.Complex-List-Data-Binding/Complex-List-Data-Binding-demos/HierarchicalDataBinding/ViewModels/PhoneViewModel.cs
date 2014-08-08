using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HierarchicalDataBinding.ViewModels
{
    public class PhoneViewModel
    {
        public string Model { get; set; }
        
        public OperatingSystemViewModel OperatingSystem { get; set; }

        public IEnumerable<FeatureViewModel> Features { get; set; }

        public int Year { get; set; }

        public static Expression<Func<XElement, PhoneViewModel>> FromXElement
        {
            get
            {
                return x => new PhoneViewModel()
                {
                    Model = x.Element("model").Value,
                    Year = int.Parse(x.Element("year").Value),
                    OperatingSystem = new OperatingSystemViewModel()
                    {
                        Name = x.Element("operatingSystem").Element("name").Value,
                        Version = x.Element("operatingSystem").Element("version").Value,
                    },
                    Features = x.Element("features")
                                .Elements("feature")
                                .AsQueryable()
                                .Select(FeatureViewModel.FromXElement)
                };
            }
        }
    }
}
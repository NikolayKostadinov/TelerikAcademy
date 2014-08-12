using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Behavior_Binding.ViewModels
{
    public class PhoneViewModel
    {
        public string Vendor { get; set; }
        public string Model { get; set; }
        public OsViewModel Os { get; set; }
        public int Year { get; set; }
        public string ImagePath { get; set; }

        public static Expression<Func<XElement, PhoneViewModel>> FromXElement
        {
            get
            {
                return element =>
                    new PhoneViewModel()
                    {
                        Vendor = element.Element("vendor").Value,
                        Model = element.Element("model").Value,
                        Year = int.Parse(element.Element("year").Value),
                        ImagePath = element.Element("image").Value,
                        Os = new OsViewModel()
                        {
                            Name = element.Element("os").Element("name").Value,
                            Version = element.Element("os").Element("version").Value,
                            Manufacturer = element.Element("os").Element("manufacturer").Value,
                        }
                    };
            }

        }
    }
}

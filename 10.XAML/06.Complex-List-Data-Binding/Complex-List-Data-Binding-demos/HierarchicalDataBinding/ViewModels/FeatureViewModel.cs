using System;
using System.Linq.Expressions;
using System.Xml.Linq;
namespace HierarchicalDataBinding.ViewModels
{
    public class FeatureViewModel
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public static Expression<Func<XElement, FeatureViewModel>> FromXElement
        {
            get
            {
                return x => new FeatureViewModel()
                {
                    Name = x.Element("name").Value,
                    Value = x.Element("value").Value
                };
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Behavior_Binding.ViewModels
{
    public class DataPersister
    {
        public static IEnumerable<PhoneViewModel> GetPhonesFromXml(string xmlPath)
        {
            XDocument doc = XDocument.Load(xmlPath);
            var root = doc.Root;
            var phones = root.Elements("phone")
                .AsQueryable()
                .Select(PhoneViewModel.FromXElement);
            return phones;
        }
    }
}

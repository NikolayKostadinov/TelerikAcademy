using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace PhonesStore.ViewModels
{
    public class DataPersister
    {
        public static IEnumerable<PhoneViewModel> GetAll(string phonesStoreDocumentPath)
        {
            var phonesDocumentRoot = XDocument.Load(phonesStoreDocumentPath).Root;

            var phonesVMs =
                           from phoneElement in phonesDocumentRoot.Elements("phone")
                           select new PhoneViewModel()
                           {
                               Vendor = phoneElement.Element("vendor").Value,
                               Model = phoneElement.Element("model").Value,
                               Year = int.Parse(phoneElement.Element("year").Value),
                               ImagePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), phoneElement.Element("image").Value),
                               OS = new OperatingSystemViewModel()
                               {
                                   Name = phoneElement.Element("os").Element("name").Value,
                                   Manufacturer = phoneElement.Element("os").Element("manufacturer").Value,
                                   Version = phoneElement.Element("os").Element("version").Value,
                               }
                           };
            return phonesVMs;
        }
    }
}
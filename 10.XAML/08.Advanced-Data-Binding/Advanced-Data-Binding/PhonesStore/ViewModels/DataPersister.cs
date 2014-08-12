using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace PhonesStore.ViewModels
{
    public class DataPersister
    {
        public static IEnumerable<PhoneViewModel> GetPhones(string phonesStoreDocumentPath)
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

        internal static IEnumerable<OperatingSystemViewModel> GetAllOperationalSystems(string phonesStoreDocumentPath)
        {
            var phonesDocumentRoot = XDocument.Load(phonesStoreDocumentPath).Root;

            var osVms =
                       from phoneElement in phonesDocumentRoot.Elements("phone")
                       select new OperatingSystemViewModel()
                       {
                           Name = phoneElement.Element("os").Element("name").Value,
                           Manufacturer = phoneElement.Element("os").Element("manufacturer").Value,
                           Version = phoneElement.Element("os").Element("version").Value,
                       };
            return osVms.Union(new List<OperatingSystemViewModel>());
        }

        internal static void AddPhone(string documenPath, PhoneViewModel phone)
        {
            var root = XDocument.Load(documenPath).Root;
            root.Add(new XElement("phone",
                new XElement("vendor", phone.Vendor),
                new XElement("model", phone.Model),
                new XElement("year", phone.Year),
                new XElement("image", phone.ImagePath),
                new XElement("os",
                        new XElement("name", phone.OS.Name),
                        new XElement("version", phone.OS.Name),
                        new XElement("manufacturer", phone.OS.Manufacturer))));
            root.Document.Save(documenPath);
        }
    }
}
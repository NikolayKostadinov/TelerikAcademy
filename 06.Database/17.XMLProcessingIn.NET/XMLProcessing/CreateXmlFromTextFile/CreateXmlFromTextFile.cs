namespace CreateXmlFromTextFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    class CreateXmlFromTextFile
    {
        private class Man
        {
            public string Name { get; set; }

            public string Address { get; set; }

            public string Phone { get; set; }
        }
        static void Main()
        {
            IList<Man> people = new List<Man>();
            string filename = "../../peoples.txt";
            if (File.Exists(filename))
            {
                ReadTextFileToList(people, filename);
                SaveManToXml(people);
            }
            else
            {
                Console.WriteLine("File Not Found!");
            }
        }

        private static void ReadTextFileToList(IList<Man> people, string filename)
        {
            using (StreamReader reader = File.OpenText(filename))
            {
                while (reader.Peek() > -1)
                {
                    people.Add(
                        new Man()
                            {
                                Name = reader.ReadLine(),
                                Address = reader.ReadLine(),
                                Phone = reader.ReadLine()
                            });
                }
            }
        }

        private static void SaveManToXml(IList<Man> people)
        {
            string fileName = "../../peoples.xml";

            using (XmlTextWriter writer = new XmlTextWriter(fileName, Encoding.GetEncoding("windows-1251")))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();

                writer.WriteStartElement("people");

                foreach (var man in people)
                {
                    writer.WriteStartElement("person");
                    writer.WriteElementString("name", man.Name);
                    writer.WriteElementString("address", man.Address);
                    writer.WriteElementString("phone", man.Phone);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
        }
    }
}

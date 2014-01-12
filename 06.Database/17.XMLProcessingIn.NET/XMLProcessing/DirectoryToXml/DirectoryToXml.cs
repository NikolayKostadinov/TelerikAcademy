namespace DirectoryToXml
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;

    //Write a program to traverse given directory and write to a XML file 
    //it contents together with all subdirectories and files. 
    //Use tags <file> and <dir> with appropriate attributes. 
    //For the generation of the XML document use the class XmlWriter.

    class DirectoryToXml
    {
        public static void CreateXMLForDirectory(string sourceDirectory, XmlTextWriter writer)
        {
            try
            {

                FileInfo fileInfoSource = new FileInfo(sourceDirectory);

                writer.WriteStartElement("directory");
                writer.WriteAttributeString("name", fileInfoSource.Name);

                var files = Directory.EnumerateFiles(sourceDirectory);
                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    writer.WriteStartElement("file");
                    writer.WriteElementString("name", fileInfo.Name);
                    writer.WriteElementString("type", fileInfo.Extension);
                    writer.WriteEndElement();
                }

                var directories = Directory.EnumerateDirectories(sourceDirectory);
                foreach (var directory in directories)
                {
                    CreateXMLForDirectory(directory, writer);
                }

                writer.WriteEndElement();
            }
            catch (Exception e)
            {

                throw new ArgumentException("Error" + e.Message);
            }
        }
        static void Main()
        {
            string fileName = "../../directories.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            string startDirectory = @"D:\TelerikAcademyHomeworks\Homeworks";

            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("directories");

                CreateXMLForDirectory(startDirectory, writer);

                writer.WriteEndDocument();


            }
        }
    }
}

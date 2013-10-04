namespace _10.ParseXML
{
    using System;
using System.Collections.Generic;
    using System.IO;
    using System.Text;

    class ParseXml
    {
        public static void Main()
        {
            string fileName = "test.xml";
            List<string> result = new List<string>();

            ParseXmlToString(fileName, result);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void ParseXmlToString(string fileName, List<string> result)
        {
            StreamReader reader = new StreamReader(fileName);
            string line = reader.ReadLine();

            while (line != null)
            {
                char[] chrLine = line.ToCharArray();
                bool intag = false;
                StringBuilder text = new StringBuilder();

                for (int i = 0; i < chrLine.Length; i++)
                {
                    if (chrLine[i] == '<') 
                    {
                        intag = true;
                        if (text.ToString().Trim() != string.Empty) 
                        {
                            result.Add(text.ToString()); 
                        }
                    }
                    else if (chrLine[i] == '>')
                    {
                        intag = false;
                        text.Remove(0, text.Length);
                    }
                    else if (intag == false)
                    {
                        text.Append(chrLine[i]);
                    }
                }

                line = reader.ReadLine();
            }
        }
    }
}

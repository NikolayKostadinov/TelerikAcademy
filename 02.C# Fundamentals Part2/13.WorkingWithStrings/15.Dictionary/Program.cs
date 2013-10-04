namespace _15.Dictionary
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            string fileName = @"dictionary.txt";
            string dictionary = ReadDictionary(fileName);
             Dictionary<string, string> myDictionary = 
                new Dictionary<string, string>();

            ConstructDictionary(dictionary, myDictionary);

            while (true)
            {               
                string word = Console.ReadLine().ToLower();
                try
                {
                    Console.WriteLine(myDictionary[word]);
                }
                catch (KeyNotFoundException)
                {
                    if (word == "cmd exit") 
                    {
                        break;
                    }

                    Console.WriteLine("No such a word in dictionaty");  
                }
            }
        }

        private static string ReadDictionary(string fileName)
        {
            StreamReader sr = new StreamReader(fileName, Encoding.GetEncoding("windows-1251"));
            string dictionary = sr.ReadToEnd();
            return dictionary;
        }

        private static void ConstructDictionary(string dictionary, Dictionary<string, string> myDictionary)
        {
            string pattern = @"(.*)\s[-]\s(.*)";
            string pattern1 = @"[|]";
            MatchCollection matches = Regex.Matches(dictionary, pattern);
            foreach (Match match in matches)
            {
                myDictionary.Add(
                    match.Groups[1].ToString().ToLower(), 
                    Regex.Replace(match.Groups[2].ToString(), pattern1, "\r\n"));
            }
        }
    }
}

/*Write a program that counts how many times each word from given text file 
 * words.txt appears in it. The character casing differences should be ignored. 
 * The result words should be ordered by their number of occurrences in the text. 
 * Example:
 * 
	is -> 2
	the -> 2
	this -> 3
	text -> 6
 */

namespace CountWordsInText
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    class CountWordsInText
    {
        static void Main()
        {
            string fileName = @"test.txt";
            string[] wordsFromFile = null;
            try 
	        {	        
		        wordsFromFile = ReadFile(fileName);
	        }
	        catch (IOException ex)
	        {
		        Console.WriteLine(ex.Message);
	        }
            IDictionary<string, int> couterOfWords = CountNumberOfWords(wordsFromFile);
            PrintResultToConsole(couterOfWords);
        }

        private static string[] ReadFile(string fileName)
        {
            string readedString = string.Empty;
            using ( StreamReader reader = new StreamReader(fileName, Encoding.GetEncoding("windows-1251")))
            {
                readedString = reader.ReadToEnd();
            }
            string[] words = readedString.Split((@", ?!.-–""/\"+"\n"+"\r").ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            return words;
        }

        private static Dictionary<string, int> CountNumberOfWords(string[] wordsFromFile)
        {
            Dictionary<string, int> countersOfWords = new Dictionary<string, int>();
            foreach (string word in wordsFromFile)
            {
                string lowerWord = word.ToLower();
                if (countersOfWords.ContainsKey(lowerWord))
                {
                    countersOfWords[lowerWord]++;
                }
                else 
                {
                    countersOfWords.Add(lowerWord, 1);
                }
            }

            return countersOfWords;
        }

        private static void PrintResultToConsole(IDictionary<string, int> counterOfWords)
        {
            foreach (var word in counterOfWords.OrderBy(x => x.Value))
            {
                Console.WriteLine("{0} -> {1}", word.Key, word.Value);
            }
        }
    }
}

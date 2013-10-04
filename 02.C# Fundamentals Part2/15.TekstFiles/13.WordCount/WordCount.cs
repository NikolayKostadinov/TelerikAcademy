namespace _13.WordCount
{
    /* TODO: Напишете програма, която прочита списък от думи от файл, 
     наречен words.txt, преброява колко пъти всяка от тези думи 
     се среща в друг файл text.txt и записва резултата в трети 
     файл – result.txt, като преди това ги сортира по броя срещания
     в намаляващ ред. Прихванете всички възможни изключения (Exceptions). */
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class WordsCount
    { 
        public string Word { set; get; }
        public ulong Count { set; get; }

        public WordsCount(string word, ulong count = 0)
        {
            this.Word = word;
            this.Count = count;
        }
    }

    class WordCount
    {
        static void Main(string[] args)
        {
            try
            {
                string wordsFileName = @"..\..\words.txt";
                string targetFileName = @"..\..\target.txt";
                string resultFileName = @"..\..\result.txt";
                WordsCount[] words = ReadWordsFromFile(wordsFileName);
                string[] wordsToCheck = new string[words.Length];

                for (int i = 0; i < wordsToCheck.Length; i++)
                {
                    wordsToCheck[i] = words[i].Word;
                }

                Console.WriteLine("Operation was started.");
                CountWordsInFile(targetFileName, words, wordsToCheck);
                SortArrayDescending(words);
                WriteArrayToFile(resultFileName, words);
                Console.WriteLine("Operarion finish successfully. \nThe result file is \'{0}\'.", resultFileName);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Not enought memory to complete operation!");
            }
        }

        private static void SortArrayDescending(WordsCount[] words)
        {
            Array.Sort(words, (x, y) =>
            {
                if (x.Count == y.Count) return 0;
                if (x.Count < y.Count) return 1;
                if (x.Count > y.Count) return -1;
                return 0;
            }
            );
        }

        private static void WriteArrayToFile(
            string resultFileName, WordsCount[] words)
        {
            StreamWriter writer =
                new StreamWriter(resultFileName, false, Encoding.GetEncoding("windows-1251"));
            using (writer)
            {
                writer.WriteLine("List of words with their count found in text");
                writer.WriteLine("============================================");
                writer.WriteLine();

                foreach (var item in words)
                {
                    writer.WriteLine(string.Format("{0,10} => {1,5}", item.Word, item.Count));
                }
            }

        }

        private static void CountWordsInFile(
            string targetFileName, WordsCount[] words, string[] wordsToCheck)
        {
            StreamReader reader =
                new StreamReader(targetFileName, Encoding.GetEncoding("windows-1251"));
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string delimiters = @" ?!.,<>/\""'|[]{}~`@#$%^&*()-_+=;:" + "\t" + "\n" + "\r";
                    string[] arrLine = line.Split(delimiters.ToCharArray());

                    foreach (var word in arrLine)
                    {
                        int index = Array.IndexOf(wordsToCheck, word);
                        if (index > -1)
                        {
                            words[index].Count++;
                        }
                    }

                    line = reader.ReadLine();
                }
            }
        }

        private static WordsCount[] ReadWordsFromFile(
            string wordsFileName)
        {
            List<WordsCount> wordsReaded = new List<WordsCount>();
            StreamReader reader =
                new StreamReader(wordsFileName, Encoding.GetEncoding("windows-1251"));
            using (reader)
            {
                string word = reader.ReadLine();
                while (word != null)
                {
                    WordsCount record = new WordsCount(word);
                    wordsReaded.Add(record);
                    word = reader.ReadLine();
                }

            }

            return wordsReaded.ToArray();
        }
    }
}

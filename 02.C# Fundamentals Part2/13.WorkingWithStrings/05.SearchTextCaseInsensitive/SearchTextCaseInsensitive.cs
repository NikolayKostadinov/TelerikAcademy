/* TODO: Напишете програма, която открива колко пъти даден подниз се 
 * съдържа в текст. Например нека търсим подниза "in" в текста: 
 * We are living in a yellow submarine. We don't have anything 
 * else. Inside the submarine is very tight. So we are drinking 
 * all the day. We will move out of it in 5 days.*/

namespace _05.SearchTextCaseInsensitive
{
    using System;

    public class SearchTextCaseInsensitive
    {
        public static void Main()
        {
            string searchedString = "in".ToLower();
            string testString = @"We are living in a yellow submarine. We don't have anything 
else. Inside the submarine is very tight. So we are drinking 
all the day. We will move out of it in 5 days.".ToLower(); 
            int findingCounter = 0;
            int foundIx = 0;

            while (true)
            {
                foundIx = testString.IndexOf(searchedString, foundIx + 1);

                if (foundIx < 0)
                {
                    break;
                }
                else
                {
                    findingCounter++;
                }
            }

            Console.WriteLine(
                "String \"{0}\" was found {1} times in the text.", 
                searchedString, 
                findingCounter);
        }
    }
}

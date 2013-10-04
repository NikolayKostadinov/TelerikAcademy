#define TEST
namespace _16.RepleaseTags
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class RepleaseTags
    {
        public static void Main()
        {
#if TEST
            DateTime begin = DateTime.Now;
#endif

            string text = @"<p>Please visit <a href=""http://academy.telerik.com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";
            string pattern = @"(<a\shref="")(.*?)("">)+?(.*?)(</a>)+?.*?";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            text = regex.Replace(
                text, 
                (Match m) => 
                {
                    string replace = @"[URL=" + 
                        m.Groups[2].Value +
                        @"]" +
                        m.Groups[4].Value +
                        @"[/URL]";
                    return replace;
                });

#if TEST
            Console.WriteLine(DateTime.Now - begin);
#endif
            Console.WriteLine(text);
#if TEST
            Console.ReadKey();
#endif
        }
    }
}

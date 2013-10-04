/* TODO: Напишете програма, която приема URL адрес във формат:
 * [protocol]://[server]/[resource]
 * и извлича от него протокол, сървър и ресурс. 
 * Например при подаден адрес: http://www.devbg.org/forum/index.php резултатът е:
 * [protocol]="http"
 * [server]="www.devbg.org"
 * [resource]="/forum/index.php" */
 
namespace _13.ParsingUrl
{
    using System;
    using System.Text.RegularExpressions;

    public class ParsingUrl
    {
        public static void Main()
        { 
            string text = @"http://life.dir.bg/cat.php?id=120";
            string expression = @"^(\w*)://([^/\r\n]+)(/[^\r\n]*)$";
            DateTime begin = DateTime.Now;

            Match match = Regex.Match(text, expression);

            Console.WriteLine("[protocol]=" + match.Groups[1].Value);
            Console.WriteLine("[server]=" + match.Groups[2].Value);
            Console.WriteLine("[resource]=" + match.Groups[3].Value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace UsingSessionObject
{
    public static class ListHelper
    {
        public static string ToHtml(this List<String> textList) 
        {
            var htmlText = new StringBuilder();
            foreach (var line in textList)
            {
                htmlText.Append(line);
                htmlText.Append("<br />");                    
            }

            return htmlText.ToString(); 
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationForm
{
    public static class HtmlMessageHelper
    {
        public static string MakeMessage(this string message, string tag)
        {
            if (tag == "br") 
            {
                return ("<br />");
            }
            var encodedMessage = HttpContext.Current.Server.HtmlEncode(message);
            return (string.Format("<{0}>{1}</{0}>", tag, encodedMessage));
        }
    }
}
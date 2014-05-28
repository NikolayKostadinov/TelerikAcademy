using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.UsingCookies
{
    public partial class Tester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            var logInCookie = Request.Cookies["UserName"];
            if (logInCookie == null)
            {
                Response.Redirect("~/LogIn.aspx");
            }
            else 
            {
                Response.Write("<h2>" + Server.HtmlDecode(logInCookie.Value) + "</h2>");
            }
        }
    }
}
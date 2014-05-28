using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.UsingCookies
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var cookie = new HttpCookie("UserName", tbUserName.Text);
            cookie.Expires = DateTime.Now.AddMinutes(1);
            Response.Cookies.Add(cookie);
            Response.Redirect("~/Tester.aspx");
        }
    }
}
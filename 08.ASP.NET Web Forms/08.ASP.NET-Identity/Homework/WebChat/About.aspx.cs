using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebChat
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated == true)
            {
                string message = "Invalid authentication";
                Response.Redirect(@"~\ErrorPage.aspx?message=" + message);
            }
        }
    }
}
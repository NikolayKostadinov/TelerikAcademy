using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.BrawserPropertiesAndClientsIpAddress
{
    public partial class BrawserAndIp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder info = new StringBuilder();
            info.Append("Browser type: " + Request.Browser.Type.ToString() + "; <br/>");
            info.Append("Client's IP Address: " + Request.UserHostAddress.ToString().Trim() + "; <br/>");
            info.Append("Client's Host Name: " + Request.UserHostName.ToString().Trim());
            this.LiteralInfo.Text = info.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssemblyInfo
{
    public partial class AssemblyInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LabelHelloCs.Text = "Hello ASP.NET Web Form from cs file";
            this.LabelAssemblyInfo.Text = Assembly.GetExecutingAssembly().FullName +": " + Assembly.GetExecutingAssembly().Location;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserMenuControl
{
    public partial class Dafault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var menuItems = new MenuItem[]
            {
                new MenuItem("Google","http://www.google.com"),
                new MenuItem("dir.bg","http://www.dir.bg"),
                new MenuItem("Yahoo","http://www.yahoo.com"),
            };

            MenuControl.DataSource = menuItems;
            this.MenuControl.DataBind();
        }
    }
}
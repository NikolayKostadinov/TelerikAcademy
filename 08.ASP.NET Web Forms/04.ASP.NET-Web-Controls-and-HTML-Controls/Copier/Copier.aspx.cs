using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Copier
{
    public partial class Copier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonCopy_Click(object sender, EventArgs e)
        {
            var input = this.TextBoxInput.Text;
            TextBoxCopy.Text = this.Server.HtmlEncode(input);
        }
    }
}
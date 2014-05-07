using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsingSessionObject
{
    public partial class UsingSessionObject : System.Web.UI.Page
    {
        private List<String> text = new List<String>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetTextDataFromSession();
                lbOutput.Text = text.ToHtml();
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            GetTextDataFromSession();
            text.Add(tbInput.Text);
            lbOutput.Text = text.ToHtml();
            Session["Text"] = text;
        }

        
        private void GetTextDataFromSession()
        {
            if (Session["Text"] != null)
            {
                text = (List<String>)Session["Text"];
            }
        }
    }
}
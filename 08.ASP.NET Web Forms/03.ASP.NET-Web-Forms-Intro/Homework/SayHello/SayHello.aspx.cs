namespace SayHello
{
    using System;

    public partial class SayHello : System.Web.UI.Page
    {
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            LabelHello.Text = "Hello " + TextBoxName.Text;
        }
    }
}
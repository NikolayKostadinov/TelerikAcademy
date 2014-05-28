using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFotoAlbum
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [System.Web.Services.WebMethod]
        public static AjaxControlToolkit.Slide[] GetSlides() 
        {
            AjaxControlToolkit.Slide[] slides = new AjaxControlToolkit.Slide[10];
            slides[0] = new AjaxControlToolkit.Slide("images/1.jpg", "Golden gate", "A picture of Sf golden gate");
            slides[1] = new AjaxControlToolkit.Slide("images/2.jpg", "San Francisco", "A picture of Sf city");
            slides[2] = new AjaxControlToolkit.Slide("images/3.jpg", "Cat", "Cat");
            slides[3] = new AjaxControlToolkit.Slide("images/4.jpg", "SF railway", "A picture of SF railway");
            slides[4] = new AjaxControlToolkit.Slide("images/5.jpg", "Night in SF", "Night in SF");
            slides[5] = new AjaxControlToolkit.Slide("images/6.jpg", "San Francisco", "A picture of Sf city");
            slides[6] = new AjaxControlToolkit.Slide("images/7.jpg", "Night in SF", "Night in SF");
            slides[7] = new AjaxControlToolkit.Slide("images/8.jpg", "San Francisco", "An picture of Sf city");
            slides[8] = new AjaxControlToolkit.Slide("images/9.jpg", "Some building", "A picture of Some building");
            slides[9] = new AjaxControlToolkit.Slide("images/10.jpg", "Tree", "A picture of tree");

            return (slides);
        }

        protected void image_Click(object sender, ImageClickEventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "key", "launchModal();", true);
        }
    }
}
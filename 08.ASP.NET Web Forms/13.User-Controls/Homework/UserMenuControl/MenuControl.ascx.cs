using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserMenuControl
{
    public partial class MenuControl : System.Web.UI.UserControl
    {
        public MenuControl() 
        {
            this.Font = "normal 20px Arial";
            FontColor = Color.FromName("red");
        }
        public string Font { get; set; }

        public Color FontColor { get; set; }

        public string ColorAsString 
        {
            get 
            {
                return this.ToWebColor(this.FontColor);
            }
        }

        public IEnumerable<MenuItem> DataSource 
        {
            get 
            {
                return (IEnumerable<MenuItem>)MenuDataList.DataSource; 
            }

            set 
            {
                this.MenuDataList.DataSource = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public override void DataBind()
        {
            MenuDataList.DataBind();
            base.DataBind();
        }

        private string ToWebColor(Color color)
        {
            if (color.IsNamedColor)
            {
                return color.Name;
            }
            else
            {
                return String.Format(
                    "color: #{0:x}{1:x}{2:x}; ",
                    color.R, color.G, color.B);
            }
        }
    }
}
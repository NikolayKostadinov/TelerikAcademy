using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _05.GraphicalCounterApplicationState
{
    public partial class Counter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Application.Lock();
            if (Application["Users"] == null)
            {
                Application["Users"] = 0;
            }

            int counter = (int)Application["Users"];
            Application["Users"] = ++counter;
            this.tbCounter.Text = counter.ToString();
            using (Bitmap generatedPicture = new Bitmap(150, 50)) 
            {
                using (Graphics gr = Graphics.FromImage(generatedPicture))
                {
                    gr.FillRectangle(Brushes.Aquamarine, 0, 0, 150, 50);
                    gr.DrawRectangle(Pens.Aqua, 5, 5, 140, 40);
                    gr.DrawString(counter.ToString(), new Font("Copperplate Gothic Light", 20, FontStyle.Regular), Brushes.BlueViolet,7,7);
                }
                Response.Clear();
                Response.ContentType = "image/jpeg";
                generatedPicture.Save(Response.OutputStream, ImageFormat.Jpeg);
            }
            Application.UnLock();
        }
    }
}
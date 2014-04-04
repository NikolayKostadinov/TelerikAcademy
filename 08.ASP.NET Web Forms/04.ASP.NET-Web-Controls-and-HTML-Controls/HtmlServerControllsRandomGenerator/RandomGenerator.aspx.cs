using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HtmlServerControllsRandomGenerator
{
    public partial class RandomGenerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Submit_ServerClick(object sender, EventArgs e)
        {
            try
            {
                var valueFrom = int.Parse(this.inputValueFrom.Value);
                var valueTo = int.Parse(this.inputValueTo.Value);
                this.Result.InnerText = GetRandomNumber(valueFrom, valueTo + 1);
            }
            catch (Exception ex)
            {
                this.Result.InnerText = "This program accepts only integer numeric input!!!";
            }
        }

        private string GetRandomNumber(int valueFrom, int valueTo)
        {
            var randomGenerator = new Random();
            var random = randomGenerator.Next(valueFrom, valueTo);
            return random.ToString();
        }
    }
}
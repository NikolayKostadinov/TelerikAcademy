using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetWebControllsRandomGenerator
{
    public partial class RandomGenerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                var valueFrom = int.Parse(this.inputValueFrom.Text);
                var valueTo = int.Parse(this.inputValueTo.Text);
                this.Result.Text = GetRandomNumber(valueFrom, valueTo + 1);
            }
            catch (FormatException ex)
            {
                this.Result.Text = "This program accepts only integer numeric input!!!";
            }
            catch (ArgumentException ex) 
            {
                this.Result.Text = ex.Message;
            }
        }

        private string GetRandomNumber(int valueFrom, int valueTo)
        {
            if (valueFrom > valueTo) 
            {
                throw new ArgumentException("Second number must be greater than first number!!!");
            }

            var randomGenerator = new Random();
            var random = randomGenerator.Next(valueFrom, valueTo);
            return random.ToString();
        }
    }
}
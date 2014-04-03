using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SumOfNumbers
{
    public partial class SumOfNumbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            int x;
            int y;

            if (int.TryParse(this.firstNumber.Text, out x) &&
                int.TryParse(this.secondNumber.Text, out y))
            {
                this.labelResult.Text = "= " + (x + y).ToString();
            }
            else 
            {
                this.labelResult.Text = "Input must be a number";
            }
        }
    }
}
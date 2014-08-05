using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalculator.Models
{
    public class Calculator
    {
        public double FirstArgument { get; set; }
        public double SecondArgument { get; set; }
        public double Result { get; set; }
        public string Operation { get; set; }

        private double CalculateResult()
        {
            switch (this.Operation)
            {
                case "MC":

                    break;
                case "MR":
                    break;
                case "MS":
                    break;
                case "M+":
                    break;
                case "M-":
                    break;
                case "←":
                    break;
                case "CE":
                    break;
                case "C":
                    break;
                case "±":
                    break;
                case "√":
                    break;
                case "/":
                    break;
                case "%":
                    break;
                case "*":
                    break;
                case "-":
                    break;
                case "+":
                    break;
                case "1/x":
                    break;
                case "=":
                    break;
                default:
                    throw new InvalidOperationException("No such operation");
            }
            return 0;
        }
    }
}

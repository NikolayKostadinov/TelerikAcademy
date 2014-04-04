using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SumOfNumbers.MVC.Models
{
    public class SumModel
    {
        [Required]
        [Display(Name = "FirstNumber")]
        public int FirstNumber { get; set; }

        [Required]
        [Display(Name = "SecondNumber")]
        public int SecondNumber { get; set; }

        [Display(Name = "Result")]
        public long Result
        {
            get
            {
                return (long)(this.FirstNumber + this.SecondNumber);
            }
        }
    }
}
namespace SchoolSystem.Repository.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using SchoolSystem.Models;

    public class MarkModel
    {
        public static Expression<Func<Mark, MarkModel>> FromMark
        {
            get
            {
                return x => new MarkModel { MarkId = x.MarkId, Subject = x.Subject, Value = x.Value };
            }
        }

        public int MarkId { get; set; }

        public string Subject { get; set; }

        public decimal Value { get; set; }
    }
}

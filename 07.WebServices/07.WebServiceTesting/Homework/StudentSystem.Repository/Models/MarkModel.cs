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

        public Mark CreateMark(Mark mark)
        {
            return new Mark() { Subject = this.Subject, Value = this.Value };
        }

        public void UpdateMark(Mark mark)
        {
            if (this.Subject != null)
            {
                mark.Subject = this.Subject;
            }

            if (2 >= this.Value && this.Value <= 6)
            {
                mark.Value = this.Value;
            }
        }
    }
}

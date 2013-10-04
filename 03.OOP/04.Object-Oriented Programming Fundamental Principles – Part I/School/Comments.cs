namespace School
{
    using System;

    public abstract class Comments
    {
        public Comments() : this(string.Empty)
        {
        }

        public Comments(string comment)
        {
            this.Comment = comment;
        }

        public string Comment { get; set; }
    }
}

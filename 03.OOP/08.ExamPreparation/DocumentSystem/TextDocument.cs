namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TextDocument : Document, IEditable
    {
        public string Charset
        {
            get
            {
                return this.GetProperty("charset").ToString();
            }

            set
            {
                this.LoadProperty("charset", value.ToString());
            }
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}


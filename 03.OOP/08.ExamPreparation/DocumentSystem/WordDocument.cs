namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class WordDocument : OfficeDocument, IEditable
    {
        public ulong NumberOfCharacters
        {
            get
            {
                return this.GetProperty("chars").ToULong();
            }

            set
            {
                this.LoadProperty("chars", value.ToString());
            }
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}


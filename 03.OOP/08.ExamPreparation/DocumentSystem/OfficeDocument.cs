namespace DocumentSystem
{
    using System;
    using System.Linq;

    public abstract class OfficeDocument : EncriptableDocument
    {
        public string Version
        {
            get
            {
                return this.GetProperty("Version").ToString();
            }

            set
            {
                this.LoadProperty("Version", value.ToString());
            }
        }
    }
}


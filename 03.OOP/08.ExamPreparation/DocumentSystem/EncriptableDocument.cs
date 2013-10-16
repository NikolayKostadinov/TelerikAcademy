namespace DocumentSystem
{
    using System;
    using System.Linq;

    public abstract class EncriptableDocument : BinaryDocument, IEncryptable
    {
        private bool isEncripted = false;

        public bool IsEncrypted
        {
            get { return this.isEncripted; }
        }

        public void Encrypt()
        {
            this.isEncripted = true; 
        }

        public void Decrypt()
        {
            this.isEncripted = false;
        }

        public override string ToString()
        {
            if (this.IsEncrypted)
            {
                return string.Format("{0}[encrypted]", this.GetType().Name);
            }
            else 
            {
                return base.ToString();
            }
        }
    }
}


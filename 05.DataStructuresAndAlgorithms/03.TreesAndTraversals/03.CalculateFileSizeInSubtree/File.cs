namespace CalculateFileSizeInSubtree
{
    using System;
    using System.IO;

    public class File
    {
        private string name = string.Empty;
        private long size = 0;

        public File(string fullPathAndName) 
        {
            this.Name = fullPathAndName;
            FileInfo fileInfo;
            try
            {
                fileInfo = new FileInfo(this.name);
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }

            if (!fileInfo.Exists)
            {
                string message = string.Format("There is no such file {0}", fullPathAndName);
                throw new ArgumentException(message);    
            }

            this.Size = fileInfo.Length;
        }

        public string Name
        {
            get 
            {
                return this.name;
            }

            private set 
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Filename cannot be empty string or white space.");
                }

                this.name = value;
            }
        }

        public long Size 
        {
            get 
            { 
                return this.size; 
            }

            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("The size of file must be a positive number.");
                }

                this.size = value;
            }
        }
    }
}

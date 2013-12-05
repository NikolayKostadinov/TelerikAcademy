namespace CalculateFileSizeInSubtree
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class Folder
    {
        private string name;
        private List<File> files = new List<File>();
        private List<Folder> childFolders = new List<Folder>();

        public Folder(string folderName)
        {
            this.name = folderName;
            GetGhildsRecursively(folderName);
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
                    throw new ArgumentException("Directory name cannot be empty string or white space.");
                }

                if (!Directory.Exists(value))
                {
                    throw new ArgumentException("There no such directory! " + value);
                }

                this.name = value;
            }
        }

        public int FilesCount
        {
            get
            {
                return this.files.Count;
            }
        }

        public int SubfoldersCount
        {
            get
            {
                return this.childFolders.Count;
            }
        }

        public File GetFileById(int id)
        {
            if (id >= 0 && id < this.files.Count)
            {
                return this.files[id];
            }
            else
            {
                throw new IndexOutOfRangeException("Index of files collection in frolder " + this.Name + " is out of range");
            }
        }

        public Folder GetSubFoldersById(int id)
        {
            if (id >= 0 && id < this.childFolders.Count)
            {
                return this.childFolders[id];
            }
            else
            {
                throw new IndexOutOfRangeException("Index of folders collection in frolder " + this.Name + " is out of range");
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        private void GetGhildsRecursively(string folderName)
        {
            string[] filesInFolder;

            try
            {
                filesInFolder = Directory.GetFiles(folderName);
            
                foreach (string file in filesInFolder)
                {
                    this.AddChildFile(new File(file));
                }

                string[] childFolders = Directory.GetDirectories(folderName);

                foreach (string folder in childFolders)
                {
                    this.AddChildFolders(new Folder(folder));                
                }
            }
            catch(UnauthorizedAccessException)
            {
                return;
            }
        }

        private void AddChildFolders(Folder folder)
        {
            this.childFolders.Add(folder);
        }

        private void AddChildFile(File file)
        {
            this.files.Add(file);
        }
    }
}

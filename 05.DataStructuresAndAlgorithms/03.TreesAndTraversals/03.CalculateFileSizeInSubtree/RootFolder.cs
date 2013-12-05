namespace CalculateFileSizeInSubtree
{
    using System;

    class RootFolder
    {
        private Folder rootFolder;

        public RootFolder(string folderPath)
        {
            this.rootFolder = new Folder(folderPath);
        }

        public long GetFolderSize(string folderName) 
        {
            Folder folder = FindFolder(folderName);
            long size = CalculateFolderSize(folder);
            return size;
        }

        private long CalculateFolderSize(Folder folder)
        {
            long calculatedSize = 0;
            
            int filesCount = folder.FilesCount;
            if (filesCount > 0)
            {
                for (int id = 0; id < filesCount; id++)
                {
                    calculatedSize += folder.GetFileById(id).Size;
                }
            }

            int subfoldersCount = folder.SubfoldersCount;

            if (subfoldersCount > 0)
            {
                for (int id = 0; id < subfoldersCount; id++)
                {
                    calculatedSize += CalculateFolderSize(folder.GetSubFoldersById(id));
                }
            }

            return calculatedSize;
        }

        private Folder FindFolder(string folderName)
        {
            if (this.rootFolder.Name == folderName)
            {
                return this.rootFolder;
            }

            Folder foundFolder = BrowseForfolderDFS(this.rootFolder, folderName);
            if (foundFolder == null)
            {
                throw new ArgumentException("Directory " + folderName + " not found!!!");
            }
            return foundFolder;
        }

        private Folder BrowseForfolderDFS(Folder folder, string folderName)
        {

            Folder foundFolder = null;
            int foldersCount = folder.SubfoldersCount;

            for (int id = 0; id < foldersCount; id++)
            {
                if (this.rootFolder.GetSubFoldersById(id).Name == folderName)
                {
                    foundFolder = this.rootFolder.GetSubFoldersById(id);
                    return foundFolder;
                }

                foundFolder = BrowseForfolderDFS(folder.GetSubFoldersById(id), folderName);
            }

            return foundFolder;
        }
    }
}

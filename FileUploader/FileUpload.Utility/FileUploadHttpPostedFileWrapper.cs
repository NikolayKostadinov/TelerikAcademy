using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace FileUpload.Utility
{
    public class FileUploadHttpPostedFileWrapper 
    {
        private int maxFileSize = Convert.ToInt32(WebConfigurationManager.AppSettings["maxRequestLength"]);
        private HttpPostedFileWrapper postedFile;
        public string FileName { get { return this.postedFile.FileName; } }
        
        public int ContentLength { get { return this.postedFile.ContentLength;} }

        public DateTime UpploadTime { get; set; }

        public FileUploadHttpPostedFileWrapper(HttpPostedFileWrapper file) 
        {
            this.postedFile = file;
        }

        public void SaveAs(string filename)
        {
            string path = Path.GetDirectoryName(filename);
            if(!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException("Пътят " + path + " не е намерен!");
            }
            if (!CheckForEnoughtFreeSpace(filename)) 
            {
                throw new System.IO.IOException("Няма достатъчно дисково пространство за извършване на операцията!");
            }
            if (System.IO.File.Exists(filename))
            {
                throw new System.IO.IOException("Файлът \"" + postedFile.FileName + "\" вече съществува.<br /> Моля изпратете файл с друго име!");  
            }

            if ((this.ContentLength / 1024) > maxFileSize)
            {
                string message = "Файлът \"" + Path.GetFileName(filename)
                            + "\" с размер: " + this.ContentLength / 1024 + "KB"
                            + " не може да бъде качен." +
                            "<br /> Размера на файла не може да надвишава " + maxFileSize / 1024 + "MB!<br />";
                throw new System.IO.IOException(message);
            }
            try
            {
                postedFile.SaveAs(filename);
            }
            catch (Exception ex) 
            {
                throw new InvalidOperationException("Файлът неможе да бъде качен.");
            }
        }
  
        /// <summary>
        /// Checks the free space.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        private bool CheckForEnoughtFreeSpace(string filename)
        {
            string path = Path.GetDirectoryName(filename);

            ManagementObject o = new ManagementObject();

            o.Path = new ManagementPath(string.Format("Win32_LogicalDisk='{0}'", path.Substring(0, 2)));

            int fileSize = postedFile.ContentLength;

            return (double)fileSize < Convert.ToDouble(o["FreeSpace"]);
        }

    }
}

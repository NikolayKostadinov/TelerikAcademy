# define DEBUG
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

        /// <summary>
        /// Save file to disk
        /// </summary>
        /// <param name="filename">file name together with full path</param>
        /// <exception cref="UnauthorizedAccessException">System.UnauthorizedAccessException</exception>
        /// <exception cref="System.InvalidOperationException">System.InvalidOperationException</exception>
        /// <exception cref="System.IO.IOException">System.IO.IOException</exception>

        public void SaveAs(string filename)
        {
            string path = Path.GetDirectoryName(filename);
            if(!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (UnauthorizedAccessException)
                {
                    throw new UnauthorizedAccessException(string.Format("Не оторизиран опит за създаване на директория {0}", path));
                }

            }
#if !DEBUG
            if (!CheckForEnoughtFreeSpace(filename)) 
            {

                throw new System.IO.IOException("Няма достатъчно дисково пространство за извършване на операцията!");
            }
#endif

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
                throw new InvalidOperationException("Файлът неможе да бъде качен.", ex);
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

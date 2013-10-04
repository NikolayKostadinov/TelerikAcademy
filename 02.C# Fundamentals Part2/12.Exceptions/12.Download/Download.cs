namespace _12.Download
{     
    using System;
    using System.Net;
    using System.IO;
   
    public class Download
    {
        public static void Main()
        {
            string targetURIName = @"http://www.devbg.org/img/";
            string destinationFile = @"Logo-BASD.jpg";
            string destinationFolder = @"D:\test\";

            Uri targetUri = new Uri(targetURIName + destinationFile);
            // Concatenate the domain with the Web resource filename.

            Console.WriteLine(
                "Downloading File \"{0}\" from \"{1}\" .......\n\n",
                destinationFile, targetUri.AbsoluteUri);
            
            try
            {
                FileDowloader(
                    targetUri,
                    destinationFile,
                    destinationFolder);

                Console.WriteLine(
                    "Successfully Downloaded File \"{0}\" from \"{1}\"",
                    destinationFile, targetUri.AbsoluteUri);
                Console.WriteLine(
                    "\nDownloaded file saved in the following file system folder:\n\t" +
                    destinationFolder);
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(
                    "File \"{0}\" not found.", 
                    destinationFolder + destinationFile);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Directory \"{0}\" does not exist!", destinationFolder);
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex);
                return;
            }
        }

        private static void FileDowloader(Uri sourceUri, string fileName,string destinationFolder)
        {
            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();
            // Download the Web resource and save it into the current filesystem folder.
            try
            {
                myWebClient.DownloadFile(sourceUri, destinationFolder + fileName);   
            }
            catch (WebException ex)
            {
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                else
                {
                    throw ex;
                }
            }
        }
    }
}

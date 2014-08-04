using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace FileUpload.Infrastructure
{
    class NonOrderingBundleOrderer : IBundleOrderer
    {
        /// <summary>
        /// Orders the files.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="files">The files.</param>
        /// <returns></returns>
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}
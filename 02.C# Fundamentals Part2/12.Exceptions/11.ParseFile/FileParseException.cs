// -----------------------------------------------------------------------
// <copyright file="FileParseException.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
namespace _11.ParseFile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Generate My Awn Exception
    /// </summary>
    public class FileParseException:System.Exception
    {
        public FileParseException()
        {
        }

        public FileParseException(string message) 
            : base(message) 
        { 
        }

        public FileParseException(string message, Exception inner)
            : base(message, inner) 
        { 
        }
    }
}

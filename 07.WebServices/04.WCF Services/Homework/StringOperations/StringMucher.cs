using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StringOperations
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class StringMucher : IStringOperations
    {

        public int GetNumberOfOccurancess(string source, string substring)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(substring))
            {
                return 0;
            }
            if (source.Length > substring.Length)
            {
                int count = 0, n = 0;

                while ((n = source.IndexOf(substring, n, StringComparison.InvariantCulture)) != -1)
                {
                    n += substring.Length;
                    ++count;
                }
                return count;
            }
            else {
                return 0;
            }
        }
    }
}

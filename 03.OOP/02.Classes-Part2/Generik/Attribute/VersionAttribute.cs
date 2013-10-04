namespace Attribute
{
    using System;
    using System.Text.RegularExpressions;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | 
        AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = true)] 
    public class VersionAttribute : System.Attribute
    {
        public VersionAttribute(double inVersion) 
        {
            string version = inVersion.ToString();
            string pattern = @"^(\d+).(\d+)$";
            Match match = Regex.Match(version, pattern);
            if (!match.Success) 
            {
                throw new ArgumentException("Invalid format. Format must be #.##");
            }
            
            this.MajorVersion = int.Parse(match.Groups[1].Value);
            this.MinorVersion = int.Parse(match.Groups[2].Value);
        }

        public int MajorVersion { get; private set; }

        public int MinorVersion { get; private set; }

        public string Version
        {
            get
            {
                return string.Format("{0}.{1}", this.MajorVersion, this.MinorVersion);
            }
        }
    }
}

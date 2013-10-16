namespace DocumentSystem
{
    using System.Collections.Generic;

    public interface IDocument
    {
        string Name { get; }

        string Content { get; }

        void LoadProperty(string key, string value);

        void SaveAllProperties(out IList<KeyValuePair<string, object>> output);

        string ToString();
    }
}
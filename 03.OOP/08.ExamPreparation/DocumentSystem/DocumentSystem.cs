namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DocumentSystem
    {
        private IList<IDocument> documents;
        
        private KeyValuePair<string, string> ParseAttribute(string attribute)
        {
           var parts = attribute.Split('=');
           return new KeyValuePair<string, string>(parts[0], parts[1]);
        }

        public DocumentSystem()
        {
            this.documents = new List<IDocument>();
        }

        private string AddDocument(IDocument document, string[] attributes)
        {
            foreach (var attribute in attributes)
            {
                var keyValue = this.ParseAttribute(attribute);
                document.LoadProperty(keyValue.Key, keyValue.Value);
            }

            this.documents.Add(document);

            if (document.Name == null)
            {
                return "Document has no name";
            }
            else
            {
                return string.Format("Document added: {0}", document.Name);
            }
        }

        public string AddTextDocument(string[] attributes)
        {
            var document = new TextDocument();
            return this.AddDocument(document, attributes); 
        }
               
        public string AddPdfDocument(string[] attributes)
        {
            var document = new PdfDocument();
            return this.AddDocument(document, attributes);     
        }              
                       
        public string AddWordDocument(string[] attributes)
        {
            var document = new WordDocument();
            return this.AddDocument(document, attributes);     
        }              
                       
        public string AddExcelDocument(string[] attributes)
        {
            var document = new ExcelDocument();
            return this.AddDocument(document, attributes);     
        }              
                       
        public string AddAudioDocument(string[] attributes)
        {
            var document = new AudioDocument();
            return this.AddDocument(document, attributes);     
        }              
                       
        public string AddVideoDocument(string[] attributes)
        {
            var document = new VideoDocument();
            return this.AddDocument(document, attributes);     
        }              
                       
        public string ListDocuments()
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (var document in documents)
            {
                sb.AppendLine(document.ToString());   
            }

            if (sb.Length == 0) 
            {
                return "No documents found";
            }

            return sb.ToString();
        }              
                       
        public string EncryptDocument(string name)
        {
            foreach (var document in this.documents)
            {
                if (document.Name == name)
                {
                    if (document is EncriptableDocument)
                    {
                        (document as EncriptableDocument).Encrypt();
                        return string.Format("Document encrypted: {0}", document.Name);
                    }
                    else
                    {
                        return string.Format("Document does not support encryption: {0}", document.Name);
                    } 
                }
            }

            return string.Format("Document not found: {0}", name);
        }              
                      
        public string DecryptDocument(string name)
        {
            foreach (var document in this.documents)
            {
                if (document.Name == name)
                {
                    if (document is EncriptableDocument)
                    {
                        (document as EncriptableDocument).Decrypt();
                        return string.Format("Document decrypted: {0}", document.Name);
                    }
                    else
                    {
                        return string.Format("Document does not support decryption: {0}", document.Name);
                    }
                }
            }

            return string.Format("Document not found: {0}", name);    
        }              
                       
        public string EncryptAllDocuments()
        {
            bool hasEncripted = false;
            
            foreach (var document in documents)
            {
                if (document is EncriptableDocument)
                {
                    hasEncripted = true;
                    (document as EncriptableDocument).Encrypt();
                }
            }

            if (hasEncripted)
            {
                return "All documents encrypted";
            }
            else
            {
                return "No encryptable documents found";
            }
        }              
                       
        public string ChangeContent(string name, string content)
        {
            foreach (var document in documents)
            {
                if (document.Name == name)
                {
                    if (document is IEditable)
                    {
                        (document as IEditable).ChangeContent(content);
                        return string.Format("Document content changed: {0}", document.Name);
                    }
                    else
                    {
                        return string.Format("Document is not editable: {0}", document.Name);
                    }
                }                
            }
            return string.Format("Document not found: {0}", name);
        }
    }
}


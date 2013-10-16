namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;

    public class ConsoleDocumentSystem
    {
        private static DocumentSystem ce;

        static void Main()
        {
            ce = new DocumentSystem();
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == string.Empty)
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                Console.WriteLine(ce.AddTextDocument(cmdAttributes)); 
            }
            else if (cmd == "AddPDFDocument")
            {
                Console.WriteLine(ce.AddPdfDocument(cmdAttributes));
            }
            else if (cmd == "AddWordDocument")
            {
                Console.WriteLine(ce.AddWordDocument(cmdAttributes));
            }
            else if (cmd == "AddExcelDocument")
            {
                Console.WriteLine(ce.AddExcelDocument(cmdAttributes));
            }
            else if (cmd == "AddAudioDocument")
            {
                Console.WriteLine(ce.AddAudioDocument(cmdAttributes));
            }
            else if (cmd == "AddVideoDocument")
            {
                Console.WriteLine(ce.AddVideoDocument(cmdAttributes));
            }
            else if (cmd == "ListDocuments")
            {
                Console.WriteLine(ce.ListDocuments());
            }
            else if (cmd == "EncryptDocument")
            {
                Console.WriteLine(ce.EncryptDocument(parameters));
            }
            else if (cmd == "DecryptDocument")
            {
                Console.WriteLine(ce.DecryptDocument(parameters));
            }
            else if (cmd == "EncryptAllDocuments")
            {
                Console.WriteLine(ce.EncryptAllDocuments());
            }
            else if (cmd == "ChangeContent")
            {
                Console.WriteLine(ce.ChangeContent(cmdAttributes[0], cmdAttributes[1]));
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }
    }
}

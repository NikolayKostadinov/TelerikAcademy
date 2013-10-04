namespace StudentsCommon
{
    using System;

    public class Speaker : ISpeakable
    {
        private readonly string speach = string.Empty;

        public Speaker(string speach)
        {
            this.speach = speach; 
        }

        public string Speak()
        {
            return "Speaker says - " + this.speach;
        }

        public void PrintSpeach()
        {
            Console.WriteLine(this.Speak());
        }
    }
}

namespace PasswordGenerator
{
    using System;
    using System.Text;

    public class PasswordGenerator
    {
        private const int PercentSpecialCharacters = 10;
        private const int PercentUpperCaseAlphabet = 10; 
        private const int PercentDigits = 10;
       
        private readonly string lowerCaseAlphabet = "abcdefghigklmnopqrstuvwxyz";
        private readonly string upperCaseAlphabet;
        private readonly string digits = "0123456789";
        private readonly string specialCharacters = @"!@#$%^&*()-_=+?/|\<>{}[]";

        public PasswordGenerator()
        {
            this.PasswordLenght = 10;
            this.upperCaseAlphabet = this.lowerCaseAlphabet.ToUpper();
        }

        public PasswordGenerator(int len)
        {
            this.PasswordLenght = len;
            this.upperCaseAlphabet = this.lowerCaseAlphabet.ToUpper();
        }

        public int PasswordLenght { get; set; }

        public string Generate()
        {
            StringBuilder password = new StringBuilder(this.PasswordLenght);
            int ix = 0;
            int currentIX = 0;

            while (ix < (this.PasswordLenght * PercentSpecialCharacters) / 100)
            {
                password.Insert(
                    RandomProvider.Next(password.Length), 
                    this.GetRandomChar(this.specialCharacters), 
                    1);
                ix++;
            }

            currentIX = ix;

            while (ix < ((this.PasswordLenght * PercentDigits) / 100) + currentIX)
            {
                password.Insert(RandomProvider.Next(password.Length), this.GetRandomChar(this.digits), 1);
                ix++;   
            }

            currentIX = ix;

            while (ix < ((this.PasswordLenght * PercentUpperCaseAlphabet) / 100) + currentIX)
            {
                password.Insert(
                    RandomProvider.Next(password.Length), 
                    this.GetRandomChar(this.upperCaseAlphabet), 
                    1);
                ix++;
            }

            while (ix < this.PasswordLenght)
            {
                password.Insert(
                    RandomProvider.Next(password.Length), 
                    this.GetRandomChar(this.lowerCaseAlphabet), 
                    1);
                ix++;
            }
            
            return password.ToString();
        }

        private string GetRandomChar(string input)
        {
            return input.ToCharArray()[RandomProvider.Next(input.Length)].ToString();
        }
    }
}

using System;

    class PlayingWithFourDigits
    {
        static void Main()
        {
            int number = 0;
            int[] digits = { 0, 0, 0, 0 };
            int sumOfDidits = 0;
            string strOutput = "";
            Console.Write("Enter four digits number: ");
            number = int.Parse(Console.ReadLine());
           //split the number
            for (int i = 0; i < 4; i++)
            {                
                digits[3-i] = (number / (int)Math.Pow(10, i)) % 10 ;                 
            } 
            // sum of the digits

            for (int i = 0; i < 4; i++)
            {
                sumOfDidits += digits[i];
            }
            Console.WriteLine("The sum of the digits of number you entered {0} is {1}", number,sumOfDidits);

            // oposite sequence
            
            for (int i = 3; i >=0; i--)
            {
                strOutput +=  digits[i];
            }
            Console.WriteLine("The entered number {0} in oposite sequence is {1} ", number,strOutput);
            strOutput = "";
            
            // last digit on first pleace
            strOutput += digits[3];
            for (int i = 0; i < 3; i++)
            {
                strOutput += digits[i];
            }
            
            Console.WriteLine("Your number now is: {0}", strOutput);
            strOutput = "";
            strOutput = digits[0].ToString() 
                + digits[2].ToString()  
                + digits[1].ToString()
                + digits[3].ToString();
                        
            Console.WriteLine("Your number now is: {0}", strOutput);
        }
    }


/* TODO: Напишете програма, която кодира текст по даден шифър 
 * като прилага шифъра побуквено с операция XOR (изключващо или) върху текста. 
 * Кодирането трябва да се извършва като се прилага XOR между пър-вата буква 
 * от текста и първата буква на шифъра, втората буква от текста и втората буква 
 * от шифъра и т.н. до последната буква от шифъра, след което се продължава отново 
 * с първата буква от шифъра и поредната буква от текста. Отпечатайте резултата 
 * като поредица от Unicode кодирани екраниращи символи.
 * Примерен текст: "Nakov". 
 * Примерен шифър: "ab". 
 * Примерен резултат: "\u002f\u0003\u000a\u000d\u0017". */

namespace _09.StringEncoder
{
    using System;
    using System.Text;

    public class StringEncoder
    {
        public static void Main()
        {
            string inputString = Console.ReadLine();
            string key = Console.ReadLine();
            int[] charsUnicode = StringToUnicode(inputString);
            int[] charKey = StringToUnicode(key);
            EncriptText(charsUnicode, charKey);
            string outputString = ConvertToString(charsUnicode);
            Console.WriteLine(outputString);
        }

        private static string ConvertToString(int[] charsUnicode)
        {
            StringBuilder reconstructor = new StringBuilder();
            
            foreach (int item in charsUnicode)
            {
                reconstructor.Append("\\u");
                reconstructor.Append(string.Format("{0:x}", item).PadLeft(4, '0'));
            }

            return reconstructor.ToString();
        }

        private static void EncriptText(int[] charsUnicode, int[] charKey)
        {
            int number = 0;
            if (charKey.Length == 0)
            {
                return; 
            }

            for (int index = 0; index < charsUnicode.Length; index++)
            {
                charsUnicode[index] = charsUnicode[index] ^ charKey[number++];
                if (number > charKey.Length - 1)
                {
                    number = 0;
                }
            }
        }
        
        private static int[] StringToUnicode(string text)
        {
            int[] chars = new int[text.Length];
            int index = 0;

            foreach (char symbol in text)
            {
                chars[index++] = symbol;    
            }

            return chars;
        }
    }
}

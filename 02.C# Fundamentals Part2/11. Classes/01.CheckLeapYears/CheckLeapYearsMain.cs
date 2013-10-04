namespace _01.CheckLeapYears
{
    using System;

    public class CheckLeapYearsMain
    {
        public static void Main()
        {
            ushort inputYear = ushort.Parse(Console.ReadLine());
            Years testYear = new Years(inputYear);
            Console.WriteLine(
                testYear.IsLeapYear() ? string.Format("The year {0} that you entered is leap.", testYear.Year) :
                string.Format("The year {0} that you entered isn't leap.", testYear.Year));
        }
    }
}
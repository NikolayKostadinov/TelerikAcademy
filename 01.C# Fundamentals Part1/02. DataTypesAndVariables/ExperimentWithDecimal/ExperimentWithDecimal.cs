using System;

class ExperimentWithDecimal
{
    static void Main()
    {
        //Decimal point aritmetics does not have abnormalities
        decimal aDecimal = 1.0M;
        decimal bDecimal = 0.33M;
        decimal sumDecimal = 1.33M;
        bool equal = (aDecimal + bDecimal == sumDecimal); //Probably True!!!
        Console.WriteLine("aDecimal+bDecimal={0}  sumDecimal={1}  equal={2}",
        aDecimal + bDecimal, sumDecimal, equal);
    }
}


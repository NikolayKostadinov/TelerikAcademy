// -----------------------------------------------------------------------
// <copyright file="RandomGenerator.cs" company="Manhattan">
// Generates random numbers between 100 and 200.
// </copyright>
// -----------------------------------------------------------------------

namespace _02.RandomNumbers
{
    using System;
    
    /// <summary>
    /// Generates random numbers between 100 and 200.
    /// </summary>
    public class RandomGenerator
    {
        private readonly ushort randomNumber;
        
        public RandomGenerator()
        {
            this.randomNumber = (ushort)RandomProvider.Next(100, 200); 
        }
        
        public ushort RandomNumbers
        {
            get
            {
                return this.randomNumber;
            }
        }

        public override string ToString()
        {
            return this.randomNumber.ToString(); 
        }
    }
}

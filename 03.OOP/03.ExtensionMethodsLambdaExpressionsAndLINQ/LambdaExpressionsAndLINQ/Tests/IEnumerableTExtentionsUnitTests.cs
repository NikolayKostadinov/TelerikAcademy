namespace Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ExpentionMethods;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IEnumerableTExtentionsUnitTests
    {
        [TestMethod]
        public void TestSumIenumerable()
        {
            List<int> tl = new List<int>() { 1, 2, 3 };
            int sum = tl.Sum<int>();
            Console.WriteLine(sum);
            Assert.AreEqual(6, sum, "Error in result of sum");
        }
    }
}

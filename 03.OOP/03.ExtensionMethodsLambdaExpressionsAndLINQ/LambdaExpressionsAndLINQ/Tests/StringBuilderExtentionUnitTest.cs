namespace Tests
{
    using System;
    using System.Text;
    using ExpentionMethods;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StringBuilderExtentionUnitTest
    {
        [TestMethod]
        public void SubstringUnitTest1()
        {
            StringBuilder sb = new StringBuilder("testing my extention.");
            StringBuilder result = sb.Substring(0, 2);
            Console.WriteLine(result);
            Assert.AreEqual("te", result.ToString(), "Error in SubstringUnitTest1");
        }

        [TestMethod]
        public void SubstringUnitTest2()
        {
            StringBuilder sb = new StringBuilder("testing my extention.");
            StringBuilder result = sb.Substring(0, sb.Length);
            Console.WriteLine(result);
            Assert.AreEqual("testing my extention.", result.ToString(), "Error in SubstringUnitTest2");
        }

        [TestMethod]
        public void SubstringUnitTest3()
        {
            StringBuilder sb = new StringBuilder("testing my extention.");
            StringBuilder result = sb.Substring(0, 0);
            Console.WriteLine(result);
            Assert.AreEqual(string.Empty, result.ToString(), "Error in SubstringUnitTest3");
        }

        [TestMethod]
        public void SubstringUnitTest4()
        {
            StringBuilder sb = new StringBuilder("testing my extention.");
            StringBuilder result = sb.Substring(3, 3);
            Console.WriteLine(result);
            Assert.AreEqual("tin", result.ToString(), "Error in SubstringUnitTest4");
        }

        [TestMethod]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void SubstringUnitTestBorder1()
        {   
            StringBuilder sb = new StringBuilder("testing my extention.");
            StringBuilder result = sb.Substring(-1, 3);
            Console.WriteLine(result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void SubstringUnitTestBorder2()
        {
            StringBuilder sb = new StringBuilder("testing my extention.");
            StringBuilder result = sb.Substring(sb.Length, 3);
            Console.WriteLine(result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void SubstringUnitTestBorder3()
        {
            StringBuilder sb = new StringBuilder("testing my extention.");
            StringBuilder result = sb.Substring(3, -1);
            Console.WriteLine(result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void SubstringUnitTestBorder4()
        {
            StringBuilder sb = new StringBuilder("testing my extention.");
            StringBuilder result = sb.Substring(sb.Length, sb.Length + 1);
            Console.WriteLine(result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void SubstringUnitTestBorder5()
        {
            StringBuilder sb = new StringBuilder("testing my extention.");
            StringBuilder result = sb.Substring(20, 2);
            Console.WriteLine(result);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindLongestSequenceOfEqualNumbers;
using System.Collections.Generic;


namespace FindLongestSequenceOfEqualNumbersTests
{
    [TestClass]
    public class FindLongestSequenceOfEqualNumbersTests
    {
        [TestMethod]
        public void GetMaximalSequenceOfEcualZero()
        {
            List<int> list = new List<int>();
            List<int> result = list.GetMaximalSequenceOfEcual();
            List<int> expected = new List<int>();
            Assert.AreEqual(expected.Count, result.Count);
        }

        [TestMethod]
        public void GetMaximalSequenceOfEcualAllDifferent()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            List<int> result = list.GetMaximalSequenceOfEcual();
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void GetMaximalSequenceOfEcualProductive()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 1, 1, 1};
            List<int> expected = new List<int> { 1, 1, 1 };
            List<int> result = list.GetMaximalSequenceOfEcual();
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void GetMaximalSequenceOfEcualProductiveBeginning()
        {
            List<int> list = new List<int>() { 1, 1, 1, 2, 3, 4, 5, 1 };
            List<int> expected = new List<int> { 1, 1, 1 };
            List<int> result = list.GetMaximalSequenceOfEcual();
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void GetMaximalSequenceOfEcualProductiveMiddle()
        {
            List<int> list = new List<int>() { 1, 2, 3, 1, 1, 1, 4, 5, };
            List<int> expected = new List<int> { 1, 1, 1 };
            List<int> result = list.GetMaximalSequenceOfEcual();
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }
}

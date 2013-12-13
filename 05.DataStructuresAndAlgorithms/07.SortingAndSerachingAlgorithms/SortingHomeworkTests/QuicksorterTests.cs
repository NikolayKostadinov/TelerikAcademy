using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingHomework;

namespace SortingHomeworkTests
{
    [TestClass]
    public class QuicksorterTests
    {
        [TestMethod]
        public void QuickSortTestWithFilledArray()
        {
            Quicksorter<int> quicksorter = new Quicksorter<int>();
            IList<int> list = new List<int>() { 9, 3, 2, 1, 4, 6, 5, 0, 8, 7 };
            IList<int> sortedList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            quicksorter.Sort(list);
            Assert.AreEqual(string.Join(",", sortedList), string.Join(",", list));
        }

        [TestMethod]
        public void QuickSortTestWithEmptyArray()
        {
            Quicksorter<int> quicksorter = new Quicksorter<int>();
            IList<int> list = new List<int>();
            IList<int> sortedList = new List<int>();

            quicksorter.Sort(list);
            Assert.AreEqual(string.Join(",", sortedList), string.Join(",", list));
        }

        [TestMethod]
        public void QuickSortTestWithOneMemberArray()
        {
            Quicksorter<int> quicksorter = new Quicksorter<int>();
            IList<int> list = new List<int>() { 1, };
            IList<int> sortedList = new List<int>() { 1, };

            quicksorter.Sort(list);
            Assert.AreEqual(string.Join(",", sortedList), string.Join(",", list));
        }
    }
}

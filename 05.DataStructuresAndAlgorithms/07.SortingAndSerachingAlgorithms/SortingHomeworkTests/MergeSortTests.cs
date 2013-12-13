using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingHomework;

namespace SortingHomeworkTests
{
    [TestClass]
    public class MergeSortTest
    {
        [TestMethod]
        public void TestingMerge1()
        {
            List<int> list1 = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> list2 = new List<int>() { };
            MergeSorter<int> ms = new MergeSorter<int>();
            var result = ms.Merge(list1, list2);
            IList<int> sortedList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.AreEqual(string.Join(",", sortedList), string.Join(",", result));
        }

        [TestMethod]
        public void TestingMerge2()
        {
            List<int> list1 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> list2 = new List<int>() { 0 };
            MergeSorter<int> ms = new MergeSorter<int>();
            var result = ms.Merge(list1, list2);
            IList<int> sortedList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.AreEqual(string.Join(",", sortedList), string.Join(",", result));
        }

        [TestMethod]
        public void TestingMerge3()
        {
            List<int> list1 = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            List<int> list2 = new List<int>() { 9 };
            MergeSorter<int> ms = new MergeSorter<int>();
            var result = ms.Merge(list1, list2);
            IList<int> sortedList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.AreEqual(string.Join(",", sortedList), string.Join(",", result));
        }

        [TestMethod]
        public void TestingMerge4()
        {
            List<int> list1 = new List<int>() { 5, 6, 7, 8, 9 };
            List<int> list2 = new List<int>() { 0, 1, 2, 3, 4 };
            MergeSorter<int> ms = new MergeSorter<int>();
            var result = ms.Merge(list1, list2);
            IList<int> sortedList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.AreEqual(string.Join(",", sortedList), string.Join(",", result));
        }

        [TestMethod]
        public void TestingMerge5()
        {
            List<int> list1 = new List<int>() { 1, 4 };
            List<int> list2 = new List<int>() { 2 };
            MergeSorter<int> ms = new MergeSorter<int>();
            var result = ms.Merge(list1, list2);
            IList<int> sortedList = new List<int>() { 1, 2, 4 };

            Assert.AreEqual(string.Join(",", sortedList), string.Join(",", result));
        }

        [TestMethod]
        public void TestingMerge6()
        {
            List<int> list1 = new List<int>() { 2 };
            List<int> list2 = new List<int>() { 1, 4 };
            MergeSorter<int> ms = new MergeSorter<int>();
            var result = ms.Merge(list1, list2);
            IList<int> sortedList = new List<int>() { 1, 2, 4 };

            Assert.AreEqual(string.Join(",", sortedList), string.Join(",", result));
        }

        [TestMethod]
        public void MergeSortTestWithFilledArrayEvenRecords()
        {
            MergeSorter<int> mergesorter = new MergeSorter<int>();
            IList<int> list = new List<int>() { 9, 3, 2, 1, 4, 6, 5, 0, 8, 7 };
            IList<int> sortedList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            mergesorter.Sort(list);
            Assert.AreEqual(string.Join(",", sortedList), string.Join(",", list));
        }

        [TestMethod]
        public void MergeSortTestWithFilledArrayOddRecords()
        {
            MergeSorter<int> mergesorter = new MergeSorter<int>();
            IList<int> list = new List<int>() { 9, 3, 2, 1, 4, 6, 5, 0, 8, 7, 10 };
            IList<int> sortedList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            mergesorter.Sort(list);
            Assert.AreEqual(string.Join(",", sortedList), string.Join(",", list));
        }

        [TestMethod]
        public void MergeSortTestWithEmptyArray()
        {
            MergeSorter<int> mergesorter = new MergeSorter<int>();
            IList<int> list = new List<int>();
            IList<int> sortedList = new List<int>();

            mergesorter.Sort(list);
            Assert.AreEqual(string.Join(",", sortedList), string.Join(",", list));
        }

        [TestMethod]
        public void MergeSortTestWithOneMemberArray()
        {
            MergeSorter<int> mergesorter = new MergeSorter<int>();
            IList<int> list = new List<int>() { 1, };
            IList<int> sortedList = new List<int>() { 1, };

            mergesorter.Sort(list);
            Assert.AreEqual(string.Join(",", sortedList), string.Join(",", list));
        }


    }
}

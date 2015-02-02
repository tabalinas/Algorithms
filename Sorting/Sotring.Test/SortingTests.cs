using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;

namespace Sotring.Test {

    [TestClass]
    public class SortingTests {

        [TestMethod]
        public void BubbleSortingTest() {
            // arrage
            var array = new int[] { 2, -86, 43, -50, 62, -4, 38, 87, 7, 68 };

            // act
            new BubbleSorter<int>(array).Sort();

            // assert
            CollectionAssert.AreEqual(new int[] { -86, -50, -4, 2, 7, 38, 43, 62, 68, 87 }, array);
        }

        [TestMethod]
        public void InsertionSortingTest() {
            // arrage
            var array = new int[] { 2, -86, 43, -50, 62, -4, 38, 87, 7, 68 };

            // act
            new InsertionSorter<int>(array).Sort();

            // assert
            CollectionAssert.AreEqual(new int[] { -86, -50, -4, 2, 7, 38, 43, 62, 68, 87 }, array);
        }

        [TestMethod]
        public void MergeSortingTest() {
            // arrage
            var array = new int[] { 2, -86, 43, -50, 62, -4, 38, 87, 7, 68 };

            // act
            new MergeSorter<int>(array).Sort();

            // assert
            CollectionAssert.AreEqual(new int[] { -86, -50, -4, 2, 7, 38, 43, 62, 68, 87 }, array);
        }

        [TestMethod]
        public void QuickSortingTest() {
            // arrage
            var array = new int[] { 2, -86, 43, -50, 62, -4, 38, 87, 7, 68 };

            // act
            new QuickSorter<int>(array).Sort();

            // assert
            CollectionAssert.AreEqual(new int[] { -86, -50, -4, 2, 7, 38, 43, 62, 68, 87 }, array);
        }

        [TestMethod]
        public void HeapSortingTest() {
            // arrage
            var array = new int[] { 2, -86, 43, -50, 62, -4, 38, 87, 7, 68 };

            // act
            new HeapSorter<int>(array).Sort();

            // assert
            CollectionAssert.AreEqual(new int[] { -86, -50, -4, 2, 7, 38, 43, 62, 68, 87 }, array);
        }

        [TestMethod]
        public void CountingSortingTest() {
            // arrange
            var array = new int[] { 2, 3, 2, 5, 6, 1, 4, 6, 2, 5, 8, 9, 1, 4, 6, 4 };

            // act
            new CountingSorter(array).Sort();

            // assert
            CollectionAssert.AreEqual(new int[] { 1, 1, 2, 2, 2, 3, 4, 4, 4, 5, 5, 6, 6, 6, 8, 9 }, array);
        }

    }

}

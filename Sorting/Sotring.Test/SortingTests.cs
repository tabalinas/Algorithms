using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;

namespace Sotring.Test {

    [TestClass]
    public class SortingTests {

        [TestMethod]
        public void InsertionSortingTest() {
            // arrage
            var array = new int[] { 2, -86, 43, -50, 62, -4, 38, 87, 7, 68 };

            // act
            new InsertionSorter<int>(array).Sort();

            // assert
            CollectionAssert.AreEqual(new int[] { -86, -50, -4, 2, 7, 38, 43, 62, 68, 87 }, array);
        }

    }

}

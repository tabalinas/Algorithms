using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearch.Test {

    [TestClass]
    public class BinarySearchTests {

        [TestMethod]
        public void BinarySearchTest() {
            // arrange
            var array = new int[] { -86, -50, -4, 2, 7, 38, 43, 62, 68, 87 };

            // act
            int result = ArrayUtils.BinarySearch(array, -50);

            // assert
            Assert.AreEqual(1, result, "item -50 is at index 1");
        }

        [TestMethod]
        public void BinarySearchOfLastItemTest() {
            // arrange
            var array = new int[] { -86, -50, -4, 2, 7, 38, 43, 62, 68, 87 };

            // act
            int result = ArrayUtils.BinarySearch(array, 87);

            // assert
            Assert.AreEqual(9, result, "item 87 is at index 9");
        }

        [TestMethod]
        public void BinarySearchOfNonExistingItemTest() {
            // arrange
            var array = new int[] { -86, -50, -4, 2, 7, 38, 43, 62, 68, 87 };

            // act
            int result = ArrayUtils.BinarySearch(array, 100);

            // assert
            Assert.AreEqual(-1, result, "-1 is returned for non-existing item");
        }

    }


}

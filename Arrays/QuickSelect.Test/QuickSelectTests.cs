using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuickSelect.Test {

    [TestClass]
    public class QuickSelectTests {

        [TestMethod]
        public void QuickSelectTest() {
            // arrange
            var array = new int[] { 2, -86, 43, -50, 62, -4, 38, 87, 7, 68 };

            // act
            var result = new QuickSelector<int>(array).FindNth(5);

            // assert
            Assert.AreEqual(38, result, "item 38 is at index 5 if arrays would be sorted");
        }

        [TestMethod]
        public void QuickSelectForLastItemTest() {
            // arrange
            var array = new int[] { 2, -86, 43, -50, 62, -4, 38, 87, 7, 68 };

            // act
            var result = new QuickSelector<int>(array).FindNth(9);

            // assert
            Assert.AreEqual(87, result, "item 87 is last and has index 9");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void QuickSelectForIndexOutOfRangeThrowsArgumentExceptionTest() {
            // arrange
            var array = new int[] { 2, -86, 43, -50, 62, -4, 38, 87, 7, 68 };

            // act
            var result = new QuickSelector<int>(array).FindNth(10);
        }

    }


}

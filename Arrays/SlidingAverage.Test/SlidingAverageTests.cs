using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SlidingAverage.Test {
    
    [TestClass]
    public class SlidingAverageTests {

        [TestMethod]
        public void SlidingAverageTest() {
            // arrange
            double[] source = new double[] { 3, 0, 3, 6, 1, 5, 4 };
            int windowSize = 3;
            double[] expectedResult = new double[] { 2, 3, 10/3.0, 4, 10/3.0, 4.5, 4 };

            // act
            double[] result = ArrayUtils.SlidingAverage(source, windowSize);

            // assert
            CollectionAssert.AreEqual(expectedResult, result);
        }
    }

}

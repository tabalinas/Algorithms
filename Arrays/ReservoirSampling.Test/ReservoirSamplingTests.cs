using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReservoirSampling.Test {

    [TestClass]
    public class ReservoirSamplingTests {

        [TestMethod]
        public void ReservoirSamplingTest() {
            // arrange
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int subsequenceSize = 5;

            // act
            int[] result = new ReservoirSampler<int>(array).GetRandomSubsequence(subsequenceSize);

            // assert
            Assert.AreEqual(5, result.Length);
            foreach(int num in result) {
                Assert.IsTrue(array.Contains(num));
            }
        }

    }

}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongestIncreasingSubsequence.Test {

    [TestClass]
    public class LongestIncreasingSubsequenceTests {

        [TestMethod]
        public void FindLongestIncreasingSubsequenceRecursive() {
            // arrange
            int[] array = new int[] { 100, 1, 11, 2, 12, 3, 4 };

            // act
            int result = new SequenceHelper().FindLongestIncreasingSubsequence(array);

            // assert
            Assert.AreEqual(4, result, "The length of the longest increasing subsequence should be four since it is { 1, 2, 3, 4 }");
        }

    }

}

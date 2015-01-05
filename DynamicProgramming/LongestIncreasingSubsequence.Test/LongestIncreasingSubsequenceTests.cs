using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongestIncreasingSubsequence.Test {

    [TestClass]
    public class LongestIncreasingSubsequenceTests {
        
        [TestMethod]
        public void FindLongestIncreasingSubsequenceTest() {
            // arrange
            int[] array = new int[] { 100, 1, 11, 2, 12, 3, 4 };

            // act
            int[] result = new SequenceHelper().FindLongestIncreasingSubsequence(array);

            // assert
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4 }, result); 
        }

    }

}

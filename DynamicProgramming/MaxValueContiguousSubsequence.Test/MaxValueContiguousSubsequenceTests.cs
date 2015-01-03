using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxValueContiguousSubsequence.Test {

    [TestClass]
    public class MaxValueContiguousSubsequenceTests {

        [TestMethod]
        public void FindMaxValueContiguousSubsequenceTest() {
            // arrange
            int[] array = new int[] { -1, 11, -5, 13, -3, 2 };

            // act
            int[] result = new SequenceHelper().FindMaxValueContiguousSubsequence(array);

            // assert
            CollectionAssert.AreEqual(new int[] { 11, -5, 13 }, result);
        }

    }

}

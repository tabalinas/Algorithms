using System;
using LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FindNthLastElement.Test {

    [TestClass]
    public class FindNthLastElementTests {

        [TestMethod]
        public void Find5thLastElementOfLinkedListTest() {
            // arrange
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            LinkedList<int> list = new LinkedList<int>(array);

            // act
            int result = list.FindLast(5);

            // assert
            Assert.AreEqual(6, result, "6 is the 5th element of the linked list");
        }

        [TestMethod]
        public void TryFindLastElementOfIndexGreaterThanSizeOfLinkedListTest() {
            // arrange
            int[] array = new int[] { 1, 2, 3, 4 };
            LinkedList<int> list = new LinkedList<int>(array);

            // act
            int result = list.FindLast(5);

            // assert
            Assert.AreEqual(0, result);
        }

    }

}

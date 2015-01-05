using System;
using LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReverseLinkedList.Test {

    [TestClass]
    public class ReverseLinkedListTests {

        [TestMethod]
        public void ReverseLinkedListTest() {
            // arrange
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            LinkedList<int> list = new LinkedList<int>(array);

            // act
            list.Reverse();

            // assert
            Assert.AreEqual("5->4->3->2->1", list.ToString());
        }

        [TestMethod]
        public void ReverseSingleElementLinkedListTest() {
            // arrange
            int[] array = new int[] { 1 };
            LinkedList<int> list = new LinkedList<int>(array);

            // act
            list.Reverse();

            // assert
            Assert.AreEqual("1", list.ToString());
        }

    }

}

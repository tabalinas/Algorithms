using System;
using LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReorderingLinkedList.Test {

    [TestClass]
    public class ReorderingLinkedListTests {

        [TestMethod]
        public void ReorderLinkedListWithOddAmountOfElementsTest() {
            // arrange
            LinkedList<int> list = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            
            // act
            list.Reorder();

            // assert
            Assert.AreEqual("1->7->2->6->3->5->4", list.ToString());
        }

        [TestMethod]
        public void ReorderLinkedListWithEvenAmountOfElementsTest() {
            // arrange
            LinkedList<int> list = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5, 6 });

            // act
            list.Reorder();

            // assert
            Assert.AreEqual("1->6->2->5->3->4", list.ToString());
        }

    }

}

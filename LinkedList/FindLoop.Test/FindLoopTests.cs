using System;
using LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FindLoop.Test {

    [TestClass]
    public class FindLoopTests {

        [TestMethod]
        public void FindLoopInLinkedListTest() {
            // arrange
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            LinkedList<int> list = new LinkedList<int>(array);
            AddLoop(list, 10, 5);

            // act
            int result = list.FindLoop();

            // assert
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void FindLoopInLinkedListWithLoopToHeadTest() {
            // arrange
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            LinkedList<int> list = new LinkedList<int>(array);
            AddLoop(list, 10, 1);

            // act
            int result = list.FindLoop();

            // assert
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void TryFindLoopInLinkedListWithoutLoopTest() {
            // arrange
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            LinkedList<int> list = new LinkedList<int>(array);

            // act
            int result = list.FindLoop();

            // assert
            Assert.AreEqual(0, result);
        }

        private void AddLoop(LinkedList<int> list, int fromElement, int toElement) {
            list.Find(fromElement).Next = list.Find(toElement);
        }

    }

}

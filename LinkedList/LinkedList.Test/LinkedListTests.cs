using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedList.Test {

    [TestClass]
    public class LinkedListTests {

        [TestMethod]
        public void CreateLinkedListTest() {
            // arrange
            int[] array = new int[] { 1, 2, 3 };

            // act
            LinkedList<int> list = new LinkedList<int>(array);

            // assert
            Assert.AreEqual("1->2->3", list.ToString());
        }

        [TestMethod]
        public void InsertItemInLinkedListTest() {
            // arrange
            LinkedList<int> list = new LinkedList<int>(new int[] { 1, 2, 3 });
            int itemToInsert = 4;

            // act
            list.Insert(itemToInsert);

            // assert
            Assert.AreEqual("1->2->3->4", list.ToString());
        }

        [TestMethod]
        public void InsertMultipleItemsInLinkedListTest() {
            // arrange
            LinkedList<int> list = new LinkedList<int>(new int[] { 1, 2, 3 });
            int[] itemsToInsert = new int[] { 4, 5, 6 };

            // act
            list.Insert(itemsToInsert);

            // assert
            Assert.AreEqual("1->2->3->4->5->6", list.ToString());
        }

        [TestMethod]
        public void RemoveItemFromLinkedListTest() {
            // arrange
            LinkedList<int> list = new LinkedList<int>(new int[] { 1, 2, 3, 7, 4, 5, 6 });
            int itemToRemove = 7;

            // act
            bool result = list.Remove(itemToRemove);

            // assert
            Assert.AreEqual(true, result);
            Assert.AreEqual("1->2->3->4->5->6", list.ToString());
        }

        [TestMethod]
        public void RemoveFirstItemFromLinkedListTest() {
            // arrange
            LinkedList<int> list = new LinkedList<int>(new int[] { 0, 1, 2, 3, 4, 5, 6 });
            int itemToRemove = 0;

            // act
            bool result = list.Remove(itemToRemove);

            // assert
            Assert.AreEqual(true, result);
            Assert.AreEqual("1->2->3->4->5->6", list.ToString());
        }

        [TestMethod]
        public void RemoveNonExistingItemFromLinkedListTest() {
            // arrange
            LinkedList<int> list = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5, 6 });
            int itemToRemove = 100;

            // act
            bool result = list.Remove(itemToRemove);

            // assert
            Assert.AreEqual(false, result);
            Assert.AreEqual("1->2->3->4->5->6", list.ToString());
        }
    }
}

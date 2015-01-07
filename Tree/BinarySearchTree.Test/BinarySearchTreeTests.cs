using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchTree.Test {

    [TestClass]
    public class BinarySearchTreeTests {

        [TestMethod]
        public void AddElementsToBinarySearchTreeTest() {
            // arrange
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
 
            // act
            tree.Add(10);
            tree.Add(5);
            tree.Add(15);
            tree.Add(1);
            tree.Add(9);
            tree.Add(11);
            tree.Add(19);

            // assert
            Assert.AreEqual("(((1) <- 5 -> (9)) <- 10 -> ((11) <- 15 -> (19)))", tree.ToString());
        }

        [TestMethod]
        public void FindElementInBinarySearchTreeTest() {
            // arrange
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(10);
            tree.Add(5);
            tree.Add(15);

            // act
            bool has15 = tree.Contains(15);
            bool has30 = tree.Contains(30);

            // assert
            Assert.IsTrue(has15);
            Assert.IsFalse(has30);
        }

        [TestMethod]
        public void InOrderTraversalTest() {
            // arrange
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(10);
            tree.Add(5);
            tree.Add(15);
            tree.Add(1);
            tree.Add(9);

            // act
            StringBuilder result = new StringBuilder();
            tree.InOrder(val => result.Append(val + " "));

            // assert
            Assert.AreEqual("1 5 9 10 15 ", result.ToString());
        }

        [TestMethod]
        public void PreOrderTraversalTest() {
            // arrange
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(10);
            tree.Add(5);
            tree.Add(15);
            tree.Add(1);
            tree.Add(9);

            // act
            StringBuilder result = new StringBuilder();
            tree.PreOrder(val => result.Append(val + " "));

            // assert
            Assert.AreEqual("10 5 1 9 15 ", result.ToString());
        }

        [TestMethod]
        public void PostOrderTraversalTest() {
            // arrange
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(10);
            tree.Add(5);
            tree.Add(15);
            tree.Add(1);
            tree.Add(9);

            // act
            StringBuilder result = new StringBuilder();
            tree.PostOrder(val => result.Append(val + " "));

            // assert
            Assert.AreEqual("1 9 5 15 10 ", result.ToString());
        }

        [TestMethod]
        public void LevelOrderTraversalTest() {
            // arrange
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(10);
            tree.Add(5);
            tree.Add(15);
            tree.Add(1);
            tree.Add(9);

            // act
            StringBuilder result = new StringBuilder();
            tree.LevelOrder(val => result.Append(val + " "));

            // assert
            Assert.AreEqual("10 5 15 1 9 ", result.ToString());
        }

        [TestMethod]
        public void RemoveNodeWithoutChildrenTest() {
            // arrange
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(10);
            tree.Add(5);
            tree.Add(15);

            // act
            tree.Remove(5);

            // assert
            Assert.AreEqual("(10 -> (15))", tree.ToString());
        }

        [TestMethod]
        public void RemoveNodeWithSingleLeftChildTest() {
            // arrange
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(10);
            tree.Add(15);
            tree.Add(5);
            tree.Add(1);

            // act
            tree.Remove(5);

            // assert
            Assert.AreEqual("((1) <- 10 -> (15))", tree.ToString());
        }

        [TestMethod]
        public void RemoveNodeWithSingleRightChildTest() {
            // arrange
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(10);
            tree.Add(15);
            tree.Add(5);
            tree.Add(7);
            tree.Add(6);
            tree.Add(8);

            // act
            tree.Remove(5);

            // assert
            Assert.AreEqual("(((6) <- 7 -> (8)) <- 10 -> (15))", tree.ToString());
        }

        [TestMethod]
        public void RemoveNodeWithBothChildrenAndLeftChildWithoutRightSubtreeTest() {
            // arrange
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(10);
            tree.Add(15);
            tree.Add(5);
            tree.Add(9);
            tree.Add(3);
            tree.Add(1);

            // act
            tree.Remove(5);

            // assert
            Assert.AreEqual("(((1) <- 3 -> (9)) <- 10 -> (15))", tree.ToString());
        }

        [TestMethod]
        public void RemoveNodeWithBothChildrenAndLeftChildWithRightSubtreeTest() {
            // arrange
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(10);
            tree.Add(7);
            tree.Add(15);
            tree.Add(3);
            tree.Add(9);
            tree.Add(1);
            tree.Add(5);
            tree.Add(4);
            tree.Add(6);

            // act
            tree.Remove(7);

            // assert
            Assert.AreEqual("((((1) <- 3 -> ((4) <- 5)) <- 6 -> (9)) <- 10 -> (15))", tree.ToString());
        }

        [TestMethod]
        public void RemoveRootNodeWithBothChildrenTest() {
            // arrange
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(10);
            tree.Add(5);
            tree.Add(15);

            // act
            tree.Remove(10);

            // assert
            Assert.AreEqual("(5 -> (15))", tree.ToString());
        }

        [TestMethod]
        public void RemoveRootNodeWithSingleChildTest() {
            // arrange
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(10);
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);

            // act
            tree.Remove(10);

            // assert
            Assert.AreEqual("((3) <- 5 -> (7))", tree.ToString());
        }

        [TestMethod]
        public void BalancedBinarySearchTreeTest() {
            // arrange
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(10);
            tree.Add(5);
            tree.Add(15);
            tree.Add(7);

            // act
            bool isBalanced = tree.IsBalanced();

            // assert
            Assert.IsTrue(isBalanced);
        }

        [TestMethod]
        public void NotBalancedBinarySearchTreeTest() {
            // arrange
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(10);
            tree.Add(5);
            tree.Add(15);
            tree.Add(7);
            tree.Add(3);
            tree.Add(1);

            // act
            bool isBalanced = tree.IsBalanced();

            // assert
            Assert.IsFalse(isBalanced);
        }
    }
}

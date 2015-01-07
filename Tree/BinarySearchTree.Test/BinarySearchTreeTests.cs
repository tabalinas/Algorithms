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
    }
}

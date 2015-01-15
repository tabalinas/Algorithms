using System;
using BinarySearchTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeLevelPrinting.Test {

    [TestClass]
    public class TreeLevelPrintingTests {

        [TestMethod]
        public void TreeLevelPrintingTest() {
            // arrange
            var tree = new BinarySearchTree<int>();
            int[] elements = new int[] { 10, 7, 3, 9, 1, 5, 15, 13, 11, 14, 20, 17, 22 };
            foreach (int el in elements) {
                tree.Add(el);
	        }

            // act
            string result = new TreePrinter<int>(tree).LevelPrint();

            // assert
            Assert.AreEqual(
@"10
7 15
3 9 13 20
1 5 11 14 17 22",
                result
            );
        }

    }

}

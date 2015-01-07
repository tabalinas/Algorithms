using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trie.Test {

    [TestClass]
    public class TrieTests {

        [TestMethod]
        public void AddWordsToTrieTest() {
            // arrange
            var trie = new Trie();

            // act
            trie.AddWord("apple");
            trie.AddWord("baloon");
            trie.AddWord("cat");
            trie.AddWord("car");
            trie.AddWord("carpet");

            // assert
            Assert.AreEqual("apple, baloon, car, carpet, cat", trie.ToString());
        }

        [TestMethod]
        public void FindWordsInTrieTest() {
            // arrange
            var trie = new Trie();
            trie.AddWord("apple");
            trie.AddWord("car");
            trie.AddWord("carbon");
            trie.AddWord("carpet");
            trie.AddWord("call");

            // act
            IList<string> result = trie.FindWords("car");

            // assert
            Assert.AreEqual("car, carbon, carpet", String.Join(", ", result.ToArray()));
        }

    }

}

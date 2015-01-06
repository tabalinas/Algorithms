using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashMap.Test {

    [TestClass]
    public class HashMapTests {

        [TestMethod]
        public void AddKeyValueTest() {
            // arrange
            HashMap<int, string> map = new HashMap<int, string>();

            // act
            map.Put(1, "one");
            map.Put(2, "two");
            map.Put(3, "three");

            // assert
            Assert.AreEqual("(1: one)(2: two)(3: three)", map.ToString());
        }

        [TestMethod]
        public void AddKeyValueWithCollisionTest() {
            // arrange
            HashMap<int, string> map = new HashMap<int, string>(16);

            // act
            map.Put(1, "one");
            map.Put(17, "seventeen");

            // assert
            Assert.AreEqual("(1: one)(17: seventeen)", map.ToString());
        }

        [TestMethod]
        public void GetValueByKeyTest() {
            // arrange
            HashMap<int, string> map = new HashMap<int, string>();
            map.Put(1, "one");

            // act
            string result = map.Get(1);

            // assert
            Assert.AreEqual("one", result);
        }

        [TestMethod]
        public void GetValueByKeyFromChainTest() {
            // arrange
            HashMap<int, string> map = new HashMap<int, string>(16);
            map.Put(1, "one");
            map.Put(17, "seventeen");

            // act
            string result = map.Get(17);

            // assert
            Assert.AreEqual("seventeen", result);
        }

        [TestMethod]
        public void RemoveItemByKeyTest() {
            // arrange
            HashMap<int, string> map = new HashMap<int, string>();
            map.Put(1, "one");
            map.Put(2, "two");
            map.Put(3, "three");

            // act
            map.Remove(2);

            // assert
            Assert.AreEqual("(1: one)(3: three)", map.ToString());
        }

        [TestMethod]
        public void RemoveItemByKeyFromChainTest() {
            // arrange
            HashMap<int, string> map = new HashMap<int, string>(16);
            map.Put(1, "one");
            map.Put(17, "seventeen");
            map.Put(33, "thirty three");

            // act
            map.Remove(17);

            // assert
            Assert.AreEqual("(1: one)(33: thirty three)", map.ToString());
        }

        [TestMethod]
        public void RemoveItemByKeyFromChainHeadTest() {
            // arrange
            HashMap<int, string> map = new HashMap<int, string>(16);
            map.Put(1, "one");
            map.Put(17, "seventeen");
            map.Put(33, "thirty three");

            // act
            map.Remove(1);

            // assert
            Assert.AreEqual("(17: seventeen)(33: thirty three)", map.ToString());
        }
    }

}

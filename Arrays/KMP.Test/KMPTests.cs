using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KMP.Test {

    [TestClass]
    public class KMPTests {

        [TestMethod]
        public void KMPSearchTest() {
            // arrange
            string source = "ABC ABCDAB ABCDABCDABDE";
            string searchValue = "ABCDABD";

            // act
            var result = new KMPSearch().StringPosition(source, searchValue);

            // assert
            Assert.AreEqual(15, result, "found at index 15");
        }

        [TestMethod]
        public void KMPSearchFailureTest() {
            // arrange
            string source = "ABC ABCDAB ABCDABCDABDE";
            string searchValue = "ABKCD";

            // act
            var result = new KMPSearch().StringPosition(source, searchValue);

            // assert
            Assert.AreEqual(-1, result, "string not found");
        }

    }
}

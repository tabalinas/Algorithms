using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParenthesesValidPairs;

namespace ParenthesesValidPair.Test {

    [TestClass]
    public class ParenthesesGeneratorTests {

        [TestMethod]
        public void GenerateParenthesesTest() {
            // arrange
            var parenthesesGenerator = new ParenthesesGenerator();
            int amountToGenerate = 3;
            HashSet<string> expectedResult = new HashSet<string>() { "((()))", "(()())", "(())()", "()(())", "()()()" };

            // act
            HashSet<string> result = parenthesesGenerator.Generate(amountToGenerate);

            // assert
            CollectionAssert.AreEqual(expectedResult.ToList(), result.ToList());
        }

    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoneyChange.Test {

    [TestClass]
    public class MoneyChangeTests {

        [TestMethod]
        public void MoneyChangeWithBacktrackingTest() {
            // arrange
            int[] coins = new int[] { 1, 5, 7 };
            int targetSum = 11;
            var changeCombiner = new ChangeCombiner(coins);

            // act
            int result = changeCombiner.MinCoinsAmountForSum(targetSum);

            // assert
            Assert.AreEqual<int>(3, result, "Minimal amount of coins should be equal to 3 (5 + 5 + 1 = 11)");
        }

    }
}

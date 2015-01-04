using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Knapsack.Test {

    [TestClass]
    public class KnapsackTests {
    
        [TestMethod]
        public void CombineKnapsack() {
            // arrange
            KnapsackItem[] items = new KnapsackItem[] {
                new KnapsackItem(50, 15),
                new KnapsackItem(40, 10),
                new KnapsackItem(70, 40),
                new KnapsackItem(30, 25),
                new KnapsackItem(25, 30)
            };
            int availableWeight = 120;

            // act
            KnapsackItem[] result = new KnapsackCombiner(items, availableWeight).Combine();

            // assert
            CollectionAssert.AreEqual(new KnapsackItem[] { items[2], items[4] }, result);
        }
    }

}

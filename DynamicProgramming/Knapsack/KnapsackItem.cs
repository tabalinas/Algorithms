using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Knapsack {
    public class KnapsackItem {
        public int Weight { get; set; }
        public int Profit { get; set; }

        public KnapsackItem(int weight, int profit) {
            Weight = weight;
            Profit = profit;
        }
    }
}

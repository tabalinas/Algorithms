using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack {

    /// <summary>
    /// Integer knapsack problem without duplicates
    /// </summary>
    public class KnapsackCombiner {

        private readonly KnapsackItem[] _items;

        public KnapsackItem[] Items {
            get { return _items; }
        }

        private readonly int _availableWeight;

        public int AvailableWeight {
            get { return _availableWeight; }
        }

        public KnapsackCombiner(KnapsackItem[] items, int availableWeight) {
            _items = items;
            _availableWeight = availableWeight;
        }

        public KnapsackItem[] Combine() {
            int[,] dp = new int[Items.Length + 1, AvailableWeight + 1];
            bool[,] chosen = new bool[Items.Length + 1, AvailableWeight + 1];

            for(int i = 1; i <= Items.Length; i++) {
                KnapsackItem item = Items[i - 1];

                for(int w = 1; w <= AvailableWeight; w++) {
                    if(w < item.Weight)
                        continue;

                    int valueWithItem = dp[i - 1, w - item.Weight] + item.Profit;
                    int valueWithoutItem = dp[i - 1, w];
                    dp[i, w] = Math.Max(valueWithItem, valueWithoutItem);
                    chosen[i, w] = valueWithItem > valueWithoutItem;
                }
            }

            return RestoreChosenItems(chosen);
        }

        private KnapsackItem[] RestoreChosenItems(bool[,] chosen) {
            List<KnapsackItem> result = new List<KnapsackItem>();

            for(int i = Items.Length, w = AvailableWeight; i > 0 && w > 0; i--) {
                if(chosen[i, w]) {
                    result.Insert(0, Items[i - 1]);
                    w -= Items[i - 1].Weight;
                }
            }

            return result.ToArray();
        }
    }
}

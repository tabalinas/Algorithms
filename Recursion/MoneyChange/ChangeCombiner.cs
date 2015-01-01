using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyChange
{
    /// <summary>
    /// How can a given amount of money be made with the least number of coins of given denominations
    /// </summary>
    public class ChangeCombiner {
        private readonly int[] _coins;

        public int[] Coins {
            get { return _coins; }
        }

        public ChangeCombiner(int[] coins) {
            _coins = coins;
        }

        public int MinCoinsAmountForSum(int sum) {
            return MinCoinsAmountForSum(sum, 0);
        }

        private int MinCoinsAmountForSum(int sum, int amount) {
            if(sum < 0)
                return int.MaxValue;

            if(sum == 0)
                return amount;

            return Coins.Select(coin => MinCoinsAmountForSum(sum - coin, amount + 1)).Min();
        }
    }
}

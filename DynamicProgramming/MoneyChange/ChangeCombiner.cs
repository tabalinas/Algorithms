using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyChange
{
    public class ChangeCombiner
    {
        private readonly int[] _coins;

        public int[] Coins {
            get { return _coins; }
        }

        public ChangeCombiner(int[] coins) {
            _coins = coins;
        }

        public int MinCoinsAmountForSum(int sum) {
            int[] dp = Enumerable.Repeat<int>(int.MaxValue, sum+1).ToArray();
            dp[0] = 0;

            for(int s = 1; s <= sum; s++) {
                foreach(int coin in Coins) {
                    if(s < coin)
                        break;

                    dp[s] = Math.Min(dp[s-coin] + 1, dp[s]);
                }
            }

            return dp[sum];
        }
    }
}

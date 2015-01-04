using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestIncreasingSubsequence {

    /// <summary>
    /// Given a sequence of n real numbers A(1) ... A(n), determine a subsequence (not necessarily contiguous) of maximum length in which the values in the subsequence form a strictly increasing sequence.
    /// </summary>
    public class SequenceHelper {

        public int[] FindLongestIncreasingSubsequence(int[] array) {
            int maxLength = 1;
            int maxEnd = 0;
            int[] dp = new int[array.Length];
            int[] prev = new int[array.Length];
            
            dp[0] = 1;
            prev[0] = -1;

            for(int i = 1; i < array.Length; i++) {
                dp[i] = 1;
                prev[i] = -1;

                for(int j = 0; j < i; j++) {
                    if(array[i] > array[j]) {
                        if(dp[j] + 1 > dp[i]) {
                            dp[i] = dp[j] + 1;
                            prev[i] = j;
                        }
                    }
                }

                if(dp[i] > maxLength) {
                    maxLength = dp[i];
                    maxEnd = i;
                }
            }

            return RestoreSubsequence(array, maxLength, maxEnd, prev);
        }

        private int[] RestoreSubsequence(int[] array, int maxLength, int maxEnd, int[] prev) {
            int[] result = new int[maxLength];

            for(int i = maxEnd, k = maxLength - 1; i > -1; i = prev[i], k--) {
                result[k] = array[i];
            }

            return result;
        }

    }

}

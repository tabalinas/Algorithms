using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxValueContiguousSubsequence {

    /// <summary>
    /// Given a sequence of n numbers A(1) ... A(n), determine a contiguous subsequence A(i) ... A(j) for which the sum of elements in the subsequence is maximized.
    /// </summary>
    public class SequenceHelper {

        public int[] FindMaxValueContiguousSubsequence(int[] array) {
            int sum = array[0];
            int maxSum = sum;
            int maxStart = 0;
            int maxEnd = 0;

            for(int i = 1, j = 0; i < array.Length; i++) {
                if(sum + array[i] > array[i]) {
                    sum = sum + array[i];
                } else {
                    sum = array[i];
                    j = i;
                }

                if(sum > maxSum) {
                    maxEnd = i;
                    maxStart = j;
                    maxSum = sum;
                }
            }

            return array.Skip(maxStart).Take(maxEnd - maxStart + 1).ToArray();
        }

    }

}

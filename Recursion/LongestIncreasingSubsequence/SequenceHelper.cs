using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestIncreasingSubsequence {

    /// <summary>
    /// Given a sequence of n real numbers A(1) ... A(n), determine a subsequence (not necessarily contiguous) of maximum length in which the values in the subsequence form a strictly increasing sequence.
    /// </summary>
    public class SequenceHelper {

        public int FindLongestIncreasingSubsequence(int[] array) {
            return FindLongestIncreasingSubsequence(array, 0, int.MinValue);
        }

        private int FindLongestIncreasingSubsequence(int[] array, int i, int prevValue) {
            if(i >= array.Length)
                return 0;

            int max = FindLongestIncreasingSubsequence(array, i + 1, prevValue);
            int length = int.MinValue;

            if(array[i] > prevValue) {
                length = FindLongestIncreasingSubsequence(array, i + 1, array[i]) + 1;
            }

            return Math.Max(max, length);
        }

    }

}


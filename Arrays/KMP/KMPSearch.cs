using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMP {

    /// <summary>
    /// Knuth-Morris-Pratt Substring Searching
    /// </summary>
    public class KMPSearch {

        public int StringPosition(string str, string searchValue) {
            int[] prefixTable = CreatePrefixTable(searchValue);

            for(int i = 0, j = 0; i < str.Length; i++) {
                while(j > 0 && str[i] != searchValue[j]) {
                    j = prefixTable[j - 1];
                }

                if(str[i] == searchValue[j]) {
                    j++;
                }

                if(j == searchValue.Length) {
                    return i - j + 1;
                }
            }

            return -1;
        }

        private int[] CreatePrefixTable(string str) {
            int[] result = new int[str.Length];

            for(int i = 1, j = 0; i < str.Length; i++) {
                while(j > 0 && str[i] != str[j]) {
                    j = result[j - 1];
                }   

                if(str[i] == str[j])
                    j++;

                result[i] = j;
            }

            return result;
        }

    }

}

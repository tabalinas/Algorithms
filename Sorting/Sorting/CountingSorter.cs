using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting {

    public class CountingSorter: Sorter<int> {

        public CountingSorter(int[] array)
            : base(array) { }

        public override void Sort() {
            int min = Array.Min();
            int max = Array.Max();

            int[] count = new int[max - min + 1];

            foreach(int num in Array) {
                count[num - min]++;
            }

            int index = 0;
            for(int i = 0; i < count.Length; i++) {
                for(int j = 0; j < count[i]; j++) {
                    Array[index++] = i + min;
                }
            }
        }

    }

}

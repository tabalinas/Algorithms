using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting {

    public class QuickSorter<T>: Sorter<T> where T: IComparable {

        public QuickSorter(T[] array)
            : base(array) { }

        public override void Sort() {
            QuickSort(0, Array.Length - 1);
        }

        private void QuickSort(int start, int end) {
            if(end <= start)
                return;

            int pivot = new Random().Next(end - start + 1) + start;

            Swap(start, pivot);

            int current = start;
            for(int i = start + 1; i <= end; i++) {
                if(Array[start].CompareTo(Array[i]) > 0) {
                    Swap(++current, i);
                }
            }

            Swap(start, current);

            QuickSort(start, current - 1);
            QuickSort(current + 1, end);
        }

    }

}

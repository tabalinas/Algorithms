using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting {

    public class HeapSorter<T>: Sorter<T> where T: IComparable {

        public HeapSorter(T[] array)
            : base(array) { }

        public override void Sort() {
            Heapify();

            for(int i = Array.Length - 1; i > 0; i--) {
                Swap(0, i);
                SiftDown(0, i);
            }
        }

        private void Heapify() {
            for(int i = Array.Length / 2; i >= 0;  i--) {
                SiftDown(i, Array.Length);
            }
        }

        private void SiftDown(int index, int heapSize) {
            int rightIndex = 2 * index + 1;
            int leftIndex = rightIndex + 1;
            int maxIndex = index;

            if(leftIndex < heapSize && Array[leftIndex].CompareTo(Array[maxIndex]) > 0) {
                maxIndex = leftIndex;
            }

            if(rightIndex < heapSize && Array[rightIndex].CompareTo(Array[maxIndex]) > 0) {
                maxIndex = rightIndex;
            }

            if(maxIndex != index) {
                Swap(index, maxIndex);
                SiftDown(maxIndex, heapSize);
            }
        }
    }

}

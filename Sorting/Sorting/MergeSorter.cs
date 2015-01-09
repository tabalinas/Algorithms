using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting {

    public class MergeSorter<T>: Sorter<T> where T: IComparable {

        public MergeSorter(T[] array)
            : base(array) { }

        public override void Sort() {
            MergeSort(0, Array.Length - 1);
        }

        private void MergeSort(int start, int end) {
            if(end <= start)
                return;

            int middle = (end - start) / 2 + start;

            MergeSort(start, middle);
            MergeSort(middle + 1, end);

            Merge(start, middle, end);
        }

        private void Merge(int start, int middle, int end) {
            T[] leftHalf = new T[middle + 1];
            System.Array.Copy(Array, leftHalf, middle + 1);

            int leftIndex = start;
            int rightIndex = middle + 1;
            int i = start;

            while(leftIndex <= middle && rightIndex <= end) {
                Array[i++] = (leftHalf[leftIndex].CompareTo(Array[rightIndex]) > 0)
                    ? Array[rightIndex++]
                    : leftHalf[leftIndex++];
            }

            while(leftIndex <= middle) {
                Array[i++] = leftHalf[leftIndex++];
            }
        }

    }

}

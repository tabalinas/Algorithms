using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting {

    public class InsertionSorter<T>: Sorter<T> where T: IComparable {

        public InsertionSorter(T[] array)
            : base(array) { }

        public override void Sort() {
            for(int i = 1; i < Array.Length; i++) {
                for(int j = i; j > 0 && Array[j-1].CompareTo(Array[j]) > 0; j--) {
                    Swap(j-1, j);
                }
            }
        }

    }

}

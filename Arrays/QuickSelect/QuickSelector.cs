using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSelect {

    /// <summary>
    /// Find the Nth element in an unordered array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QuickSelector<T> where T: IComparable {

        private readonly T[] _array;

        public T[] Array { 
            get {
                return _array;
            }
        }

        public QuickSelector(T[] array) {
            _array = array;
        }

        public T FindNth(int index) {
            if(index < 0 || index >= Array.Length)
                throw new ArgumentException("Searching index is out of range!");

            return FindNth(0, Array.Length - 1, index);
        }

        private T FindNth(int start, int end, int index) {
            Swap(start, index);

            int i = start + 1;
            int current = start;
            while(i <= end) {
                if(Array[start].CompareTo(Array[i]) > 0) {
                    Swap(++current, i);
                }
                i++;
            }

            Swap(start, current);

            switch(index.CompareTo(current)) {
                case 1:
                    return FindNth(current + 1, end, index);
                case -1:
                    return FindNth(start, current - 1, index);
                default:
                    return Array[current];
            }
        }

        private void Swap(int index1, int index2) {
            var swapping = Array[index1];
            Array[index1] = Array[index2];
            Array[index2] = swapping;
        }

    }

}

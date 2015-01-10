using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch {

    public static class ArrayUtils {

        public static int BinarySearch<T>(T[] array, T value) where T: IComparable {
            var start = 0;
            var end = array.Length - 1;

            while(end >= start) {
                int middle = (end - start) / 2 + start;

                switch(array[middle].CompareTo(value)) {
                    case -1:
                        start = middle + 1;
                        break;
                    case 1:
                        end = middle - 1;
                        break;
                    default:
                        return middle;
                }
            }

            return -1;
        }

    }

}

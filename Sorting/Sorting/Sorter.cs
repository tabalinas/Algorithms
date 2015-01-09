using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting {

    public abstract class Sorter<T> where T: IComparable {

        private readonly T[] _array;

        public T[] Array {
            get { return _array; }
        }

        public Sorter(T[] array) {
            _array = array;
        }

        public abstract void Sort();

        protected void Swap(int index1, int index2) {
            var swaping = Array[index1];
            Array[index1] = Array[index2];
            Array[index2] = swaping;
        }

    }

}

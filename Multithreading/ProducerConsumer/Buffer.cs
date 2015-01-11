using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer {

    public class Buffer<T> {

        private readonly object _sync = new object();

        private const int DEFAULT_SIZE = 10;

        private T[] _store;

        private T[] Store {
            get { return _store; }
        }

        private int _pointer = 0;

        public int Pointer {
            get { return _pointer; }
            private set { _pointer = value; }
        }

        private int Size {
            get { return Store.Length; }
        }

        public Buffer(int size = DEFAULT_SIZE) {
            _store = new T[size];
        }

        public void Write(T value) {
            lock(_sync) {
                while(Pointer >= Size) {
                    Monitor.Wait(_sync);
                }

                Store[Pointer++] = value;
                Monitor.PulseAll(_sync);
            }
        }

        public T Read() {
            lock(_sync) {
                while(Pointer <= 0) {
                    Monitor.Wait(_sync);
                }

                T value = Store[--Pointer];
                Monitor.PulseAll(_sync);
                return value;
            }
        }

    }

}

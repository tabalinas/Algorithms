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

        private int Size {
            get { return Store.Length; }
        }

        private int Tail { get; set; }
        private int Head { get; set; }
        private int Count { get; set; }

        public bool IsFull {
            get { return Count == Size; }
        }

        public bool IsEmpty {
            get { return Count == 0; }
        }

        public Buffer(int size = DEFAULT_SIZE) {
            _store = new T[size];
        }

        public void Write(T value) {
            lock(_sync) {
                while(IsFull) {
                    Monitor.Wait(_sync);
                }

                DoWrite(value);
                Monitor.PulseAll(_sync);
            }
        }

        private void DoWrite(T value) {
            Store[Tail] = value;
            Tail = ++Tail == Size ? 0 : Tail;
            Count++;
        }

        public T Read() {
            lock(_sync) {
                while(IsEmpty) {
                    Monitor.Wait(_sync);
                }

                T value = DoRead();
                Monitor.PulseAll(_sync);
                return value;
            }
        }

        private T DoRead() {
            T result = Store[Head];
            Store[Head] = default(T);
            Head = ++Head == Size ? 0 : Head;
            Count--;
            return result;
        }

        public override string ToString() {
            return String.Format("buffer: occupied {0}/{1} ({2}-{3})", Count, Size, Head, Tail);
        }

    }

}

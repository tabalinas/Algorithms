using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservoirSampling {

    public class ReservoirSampler<T> {

        private readonly T[] _source;
        private Random _rand;

        private T[] Source {
            get { return _source; }
        } 

        public ReservoirSampler(T[] source) {
            _source = source;
            _rand = new Random(Environment.TickCount);
        }

        public T[] GetRandomSubsequence(int size) {
            if(Source.Length < size)
                throw new ArgumentException("The source sequence length should be greater than getting subsequence");

            T[] result = new T[size];

            for(int i = 0; i < size; i++) {
                result[i] = Source[i];
            }

            for(int i = size; i < Source.Length; i++) {
                int j = Rand(i + 1);
                if(j < size) {
                    result[j] = Source[i];
                }
            }

            return result;
        }

        private int Rand(int max) {
            return _rand.Next(max);
        }
    }

}

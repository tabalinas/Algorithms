using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer {

    public class Producer: Worker {

        private const int MAX_VALUE_TO_GENERATE = 100;

        public Producer(Buffer<int> buffer, Action<string> logger)
            : base(buffer, logger) { }

        public override void Work() {
            Log("producer started");

            while(true) {
                int value = GetValue();
                Log("writing {0}", Buffer);
                Buffer.Write(value);
                Log("wrote \"{0}\" {1}", value, Buffer);
                Sleep();
            }
        }

        private int GetValue() {
            return Rand.Next(MAX_VALUE_TO_GENERATE + 1);
        }

    }

}

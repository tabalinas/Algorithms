using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer {

    public class Consumer: Worker {

        public Consumer(Buffer<int> buffer, Action<string> logger)
            : base(buffer, logger) { }

        public override void Work() {
            Log("consumer started");

            while(true) {
                Log("reading ({0} in buffer)", Buffer.Pointer);
                int value = Buffer.Read();
                Log("read \"{0}\" ({1} in buffer)", value, Buffer.Pointer);
                Sleep();
            }
        }

        private int GetValue() {
            return Rand.Next(100);
        }

    }

}

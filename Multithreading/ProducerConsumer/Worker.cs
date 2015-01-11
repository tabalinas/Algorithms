using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer {

    public abstract class Worker {

        private const int MAX_TIME_TO_WAIT_IN_SEC = 20;

        private readonly Buffer<int> _buffer;

        protected Buffer<int> Buffer {
            get { return _buffer; }
        }

        private readonly Action<string> _logger;

        protected Action<string> Logger {
            get { return _logger; }
        }

        private readonly Random _rand;

        protected Random Rand {
            get { return _rand; }
        }

        public Worker(Buffer<int> buffer, Action<string> logger) {
            _buffer = buffer;
            _logger = logger;
            _rand = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        }

        public abstract void Work();

        protected void Sleep() {
            Thread.Sleep(GetSleepTimeout());
        }

        private int GetSleepTimeout() {
            return Rand.Next(MAX_TIME_TO_WAIT_IN_SEC + 1) * 1000;
        }

        protected void Log(string message, params object[] param) {
            Logger(String.Format("[{1}] {0}: {2}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString("hh:mm:ss.fff"), String.Format(message, param)));
        }

    }

}

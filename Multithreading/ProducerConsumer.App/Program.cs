using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer.App {

    class Program {

        private const int PRODUCER_AMOUNT = 3;
        private const int CONSUMER_AMOUNT = 2;

        static void Main(string[] args) {
            var buffer = new Buffer<int>();

            Thread[] producers = CreateProducers(buffer);
            Thread[] consumers = CreateConsumers(buffer);

            Start(producers);
            Start(consumers);

            Join(producers);
            Join(consumers);
        }

        private static Thread[] CreateProducers(Buffer<int> buffer) {
            var result = new Thread[PRODUCER_AMOUNT];

            for(int i = 0; i < PRODUCER_AMOUNT; i++) {
                result[i] = new Thread(() => {
                    new Producer(buffer, Log).Work();
                });
            }

            return result;
        }

        private static Thread[] CreateConsumers(Buffer<int> buffer) {
            var result = new Thread[CONSUMER_AMOUNT];

            for(int i = 0; i < CONSUMER_AMOUNT; i++) {
                result[i] = new Thread(() => {
                    new Consumer(buffer, Log).Work();
                });
            }

            return result;
        }

        private static void Start(Thread[] threads) {
            foreach(var thread in threads) {
                thread.Start();
                Thread.Sleep(500);
            }
        }

        private static void Join(Thread[] threads) {
            foreach(var thread in threads) {
                thread.Join();
            }
        }

        private static void Log(string message) {
            Console.WriteLine(message);
        }

    }

}

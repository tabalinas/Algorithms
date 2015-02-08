using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiningPhilosophers.App {

    class Program {

        private const int PHILOSOPHER_AMOUNT = 5;
        private const int TIME_TO_EXECUTE_IN_SEC = 30;

        static void Main(string[] args) {
            Philosopher[] philosophers = CreatePhilosophers();
            Thread[] threads = CreateThreads(philosophers);

            Start(threads);
            
            Thread.Sleep(TIME_TO_EXECUTE_IN_SEC * 1000);

            Stop(philosophers);
            Join(threads);

            PrintReport(philosophers);
        }

        private static Philosopher[] CreatePhilosophers() {
            var result = new Philosopher[PHILOSOPHER_AMOUNT];

            Fork last = new Fork();
            Fork left = last;

            for(int i = 1; i <= PHILOSOPHER_AMOUNT; i++) {
                Fork right = i < PHILOSOPHER_AMOUNT ? new Fork() : last;
                result[i - 1] = new Philosopher(i.ToString(), left, right, Log);
                left = right;
            }

            return result;
        }

        private static Thread[] CreateThreads(Philosopher[] philosophers) {
            return philosophers
                .Select(philosopher => new Thread(() => philosopher.Run()))
                .ToArray();
        }

        private static void Start(Thread[] threads) {
            foreach(var thread in threads) {
                thread.Start();
                Thread.Sleep(500);
            }
        }

        private static void Stop(Philosopher[] philosophers) {
            foreach(var philosopher in philosophers) {
                philosopher.Stop();
            }
        }

        private static void Join(Thread[] threads) {
            foreach(var thread in threads) {
                thread.Join();
            }
        }

        private static void PrintReport(Philosopher[] philosophers) {
            foreach(var philosopher in philosophers) {
                Log(philosopher.ToString());
            }
        }

        private static void Log(string message) {
            Console.WriteLine(message);
        }

    }

}

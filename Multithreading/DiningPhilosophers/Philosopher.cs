using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiningPhilosophers {

    public class Philosopher {

        private const int MAX_TIME_TO_WAIT_IN_MS = 1000;

        public string Id { get; private set; }
        public Fork Left { get; private set; }
        public Fork Right { get; private set; }

        private int EatCount { get; set; }
        private int StartTime { get; set; }
        private int WaitTime { get; set; }

        private Action<string> Logger { get; set; }
        private Random Rand { get; set; }
        private bool Stopped { get; set; }

        public Philosopher(string id, Fork left, Fork right, Action<string> logger) {
            Id = id;
            Left = left;
            Right = right;

            Logger = logger;
            Rand = new Random(Environment.TickCount);
        }

        public void Run() {
            Log("run");

            while(!Stopped) {
                Think();

                lock(Left) {
                    Log("took left fork");

                    lock(Right) {
                        Log("took right fork");

                        Eat();
                    }
                }
            }

            Log("stopped");
        }

        private void Eat() {
            WaitTime += Environment.TickCount - StartTime;

            Log("start eating");
            Sleep();
            EatCount++;
            Log("finished eating");
        }

        private void Think() {
            Log("start thinking");
            Sleep();
            StartTime = Environment.TickCount;
            Log("finished thinking");
        }

        public void Stop() {
            Stopped = true;
        }

        private void Sleep() {
            Thread.Sleep(Rand.Next(MAX_TIME_TO_WAIT_IN_MS + 1));
        }

        private void Log(string message, params object[] param) {
            Logger(String.Format("[{1}] {0}: {2}", Id, DateTime.Now.ToString("hh:mm:ss.fff"), String.Format(message, param)));
        }

        public override string ToString() {
            return String.Format("philosopher {0} ate {1} times, waited {2}ms", Id, EatCount, WaitTime);
        }

    }
}

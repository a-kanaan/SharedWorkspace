using System;
using System.Threading;

namespace ManualResetEventSample
{
    class Program
    {
        static ManualResetEvent manualEvent;

        static Program() => manualEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            int i = 3;
            while (i-- > 0) {
                var t = new Thread(new ThreadStart(ThreadProc));
                t.Name = $"Thread_{i}";
                t.Start();
            }

            Console.WriteLine("Press Enter to send a signal to allow awating thread");
            Console.ReadKey();

            manualEvent.Set();

            Thread.Sleep(500);
            
            Console.WriteLine("Press Enter to put manualEvent in non-signal state");
            Console.ReadKey();

            manualEvent.Reset();

            var t4 = new Thread(new ThreadStart(ThreadProc));
            t4.Name = "Thread_4";
            t4.Start();

            Console.WriteLine("Press Enter to conclude the application and allow any left awaiting threads");
            Console.ReadKey();

            manualEvent.Set();
        }

        static void ThreadProc() {
            string threadName = Thread.CurrentThread.Name;
            Thread.Sleep(1000);

            manualEvent.WaitOne();
            Console.WriteLine($"thread: {threadName} has called fucntion: {nameof(ThreadProc)}");
        }
    }
}

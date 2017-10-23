using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace AutoResetSample
{
    class Program
    {
        private static AutoResetEvent autoReset;

        static Program()
        {
            // false indicates that the initial-state is not signaled
            autoReset = new AutoResetEvent(true);
        }
        static void Main(string[] args)
        {
            WriteLine("the application has started!");

            while(true){
                new Thread(new ThreadStart(Calculate)).Start();
                //Task.Run(() => Calculate());
                autoReset.WaitOne();
                WriteLine("’Method call was completed!");
            }
        }

        private static void Calculate(){
            WriteLine("Sleep is going to be called!");
            Thread.Sleep(5000);
            autoReset.Set();
            WriteLine("Set called");
        }
    }
}

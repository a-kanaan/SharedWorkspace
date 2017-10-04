using System;
using System.Linq;

namespace RunningConsoleOnDockerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Random();
            Console.WriteLine($"a simple generated word: " +
                $"{new String(Enumerable.Range(1, 10).Select(_ => (char)r.Next(60, 120)).ToArray())}");
        }
    }
}
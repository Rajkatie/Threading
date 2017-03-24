using System;
using System.Threading;

namespace AutoEvent
{
    public class Program
    {
        static AutoResetEvent autoEvent = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            new Thread(SayHello).Start();

            Console.ReadLine();

            autoEvent.Set();

            Console.ReadKey();

        }

        private static void SayHello()
        {
            Console.WriteLine("starting: " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Awaiting for signaling");
            autoEvent.WaitOne();
            Console.WriteLine("finshing");
        }
    }
}

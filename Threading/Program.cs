using System;
using System.Threading;

namespace Threading
{
   public class Program
    {
       static EventWaitHandle handle = new EventWaitHandle(false, EventResetMode.ManualReset, "localhost");
        static void Main(string[] args)
        {
            Console.WriteLine("main thread Id: " + Thread.CurrentThread.ManagedThreadId);

            Thread t1 = new Thread(SayHello);
            t1.Start("hello");
           
            new Thread(SayHello).Start("rajesh");
            new Thread(SayHello).Start("patel");

            Thread.Sleep(3000);
            handle.Set();

            //Thread.Sleep(5000);
            //handle.Set();

            Console.ReadKey();
        }

        private static void SayHello(object printMessage)
        {
            Console.WriteLine("inside method: " + printMessage + " : "+ Thread.CurrentThread.ManagedThreadId);

            handle.WaitOne();

            Console.WriteLine(printMessage);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        public static void ThreadHello()
        {
            Console.WriteLine("Hello from the thread");
            Thread.Sleep(2000);
        }

        public static void WorkOnData(object data)
        {
            Console.WriteLine($"Working on: {data}");
            Thread.Sleep(1000);
        }

        static bool tickRunning;

        public static ThreadLocal<Random> RandomGenerator = new ThreadLocal<Random>(() =>
        {
            return new Random(2);
        });

        static void Main(string[] args)
        {
            #region Create a Thread
            //Thread thread = new Thread(ThreadHello);
            //thread.Start();
            //Console.ReadKey();
            #endregion

            #region Threads ans Lambda Expressions
            //Thread thread = new Thread(() =>
            //{
            //    Console.WriteLine("Hello from the thread");
            //    Thread.Sleep(2000);
            //});
            //thread.Start();
            //Console.WriteLine("Press a key to end");
            //Console.ReadKey();
            #endregion

            #region Passing Data into a Thread
            //ParameterizedThreadStart ps = new ParameterizedThreadStart(WorkOnData);
            //Thread thread = new Thread(ps);
            //thread.Start(99);
            //Console.WriteLine("Press a key to end");
            //Console.ReadKey();

            //Passing data through Lambda Expression
            //Thread thread = new Thread((data) =>
            //{
            //    WorkOnData(data);
            //});
            //thread.Start(99);
            //Console.WriteLine("Press a key to end");
            //Console.ReadKey();
            #endregion

            #region Abort a thread
            //Thread tickThread = new Thread(() =>
            //{
            //    while (true)
            //    {
            //        Console.WriteLine("Tick");
            //        Thread.Sleep(1000);
            //    }
            //});
            //tickThread.Start();
            //Console.WriteLine("Press a key to stop the clock");
            //Console.ReadKey();
            //tickThread.Abort();
            //Console.WriteLine("Press a key to exit");
            //Console.ReadKey();

            //Aborting with a shared flag
            //tickRunning = true;
            //Thread tickThread = new Thread(() =>
            //{
            //    while(tickRunning)
            //    {
            //        Console.WriteLine("Tick");
            //        Thread.Sleep(1000);
            //    }
            //});
            //tickThread.Start();
            //Console.WriteLine("Press a key to stop the clock");
            //Console.ReadKey();
            //tickRunning = false;
            //Console.WriteLine("Press a key to exit");
            //Console.ReadKey();
            #endregion

            #region Thread Synchronization using Join
            //Thread threadToWaitFor = new Thread(() =>
            //{
            //    Console.WriteLine("Thread Starting");
            //    Thread.Sleep(2000);
            //    Console.WriteLine("Thread Done");
            //});
            //threadToWaitFor.Start();
            //Console.WriteLine("Joining Thread");
            //threadToWaitFor.Join();
            //Console.WriteLine("Press a key to exit");
            //Console.ReadKey();
            #endregion

            #region Thread data storage and ThreadLocal
            Thread t1 = new Thread(() =>
            {
                for(int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"t1: {RandomGenerator.Value.Next(10)}");
                }
            });

            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"t2: {RandomGenerator.Value.Next(10)}");
                    Thread.Sleep(500);
                }
            });

            t1.Start();
            t2.Start();
            
            Console.ReadKey();  
            #endregion

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        public static void DoWork()
        {
            Console.WriteLine("Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work finished");
            Console.ReadKey();
            Console.Clear();
        }

        public static void DoWork(int i)
        {
            if (i > 10) throw new ArgumentException($"Prohibited Value : {i}");
            Console.WriteLine($"Task {i} starting");
            Thread.Sleep(2000);
            Console.WriteLine($"Task {i} finished");
        }
        public static int CalculateResult()
        {
            Console.WriteLine("Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work finished");
            return 99;
        }
        public static void HelloTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Hello");
        }
        public static void WorldTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("World");
        }
        public static void ExceptionTask()
        {
            Console.WriteLine("Some Error");
        }
        public static void DoChild(object state)
        {
            Console.WriteLine($"Child {state} starting");
            Thread.Sleep(2000);
            Console.WriteLine($"Child {state} finished");
        }
        static void Main(string[] args)
        {
            #region Task
            //Task newTask = new Task(() => DoWork());
            //newTask.Start();
            //newTask.Wait();

            ////Run : Create and Start the task
            //Task runTask = Task.Run(() => DoWork());
            //runTask.Wait();
            //#endregion

            //#region Return a value from a task
            //Task<int> task = Task.Run(() =>
            //{
            //    return CalculateResult();
            //});
            //Console.WriteLine(task.Result);
            //Console.WriteLine("Finished processing. Press a key to end");
            //Console.ReadKey();
            #endregion

            #region Wait for tasks to complete
            //Task[] tasks = new Task[10];
            //for(int i = 0; i < tasks.Length;  i++)
            //{
            //    int taskNum = i;
            //    tasks[i] = Task.Run(() => DoWork(taskNum));
            //}
            //Task.WaitAll(tasks);
            //Console.WriteLine("Finished processing. Press a key to end.");
            //Console.ReadKey();

            //try
            //{
            //    Task[] tasks = new Task[15];
            //    for (int i = 0; i < tasks.Length; i++)
            //    {
            //        int taskNum = i+1;
            //        tasks[i] = Task.Run(() => DoWork(taskNum));
            //    }
            //    Task.WaitAll(tasks);
            //}
            //catch (AggregateException aggrExc)
            //{
            //    Console.WriteLine($"{aggrExc.InnerExceptions.Count} exceptions were thrown");
            //    foreach (var exc in aggrExc.InnerExceptions)
            //    {
            //        Console.WriteLine($"Message : {exc.Message}");
            //    }
            //}
            //finally
            //{
            //    Console.WriteLine("Finished processing. Press a key to end.");
            //    Console.ReadKey();
            //}
            #endregion

            #region Continuation Tasks
            ////Task task = Task.Run(() => HelloTask());
            ////task.ContinueWith((prevTask) => WorldTask()).Wait();

            //Task task = Task.Run(() => HelloTask());

            ////Only runs if the task is executed succesfully.
            //task.ContinueWith((prevTask) => WorldTask(), TaskContinuationOptions.OnlyOnRanToCompletion);

            ////Only runs in case of failure.
            //task.ContinueWith((prevTask) => ExceptionTask(), TaskContinuationOptions.OnlyOnFaulted);

            //Console.WriteLine("Finished processing. Press a key to end.");
            //Console.ReadKey();

            #endregion

            #region Child Tasks
            //var parent = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("Parent starts");
            //    for(int i = 0; i < 10; i++)
            //    {
            //        int taskNo = i;
            //        Task.Factory.StartNew(
            //            (x) => DoChild(x), taskNo, TaskCreationOptions.AttachedToParent
            //        );
            //    }
            //});
            //parent.Wait();
            //Console.WriteLine("Finished processing. Press a key to end.");
            //Console.ReadKey();
            #endregion
        }
    }
}

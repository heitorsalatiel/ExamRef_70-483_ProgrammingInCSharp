﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProgrammingInCSharp
{
    class Program
    {
        static void Task1()
        {
            Console.WriteLine("Task 1 starting");
            Thread.Sleep(2000);
            Console.WriteLine("Task 1 ending");
        }

        static void Task2()
        {
            Console.WriteLine("Task 2 starting");
            Thread.Sleep(1000);
            Console.WriteLine("Task 2 ending");
        }

        static void WorkOnItem(object item)
        {
            Console.WriteLine($"Standard working on : {item}");
            Thread.Sleep(1000);
            Console.WriteLine($"Finished working on: {item}");
        }

        class Person
        {
            public string Name { get; set; }
            public string City { get; set; }
        }
        static void Main(string[] args)
        {
            #region Parallel
            Parallel.Invoke(() => Task1(), () => Task2());
            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
            Console.Clear();
            #endregion

            var items = Enumerable.Range(0, 500);

            #region Parallel - ForEach
            Parallel.ForEach(items, item =>
            {
                WorkOnItem(item);
            });

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Parallel - For
            var itemsArr = items.ToArray();
            Parallel.For(0, itemsArr.Length, i =>
            {
                WorkOnItem(itemsArr[i]);
            });
            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Managing Parallel For and Parallel Foreach
            ParallelLoopResult result = Parallel.For(0, itemsArr.Count(), (int i, ParallelLoopState loopState) =>
            {
                if (i == 200) loopState.Break();
                WorkOnItem(itemsArr[i]);
            });
            Console.WriteLine($"Completed: {result.IsCompleted}");
            Console.WriteLine($"Items: {result.LowestBreakIteration}");
            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Parallel LINQ
            Person[] people = new Person[]
            {
                    new Person{Name="Alan", City="Hull"},
                    new Person{Name="Beryl", City="Seattle"},
                    new Person{Name="Charles", City="London"},
                    new Person{Name="David", City="Seattle"},
                    new Person{Name="Eddy",City="Paris"},
                    new Person{Name="Fred",City="Berlin"},
                    new Person{Name="Gordon", City="Hull"},
                    new Person{Name="Henry", City="Seattle"},
                    new Person{Name="Isaac", City="Seattle"},
                    new Person{Name="James", City="London"}
            };
            var persons = from person in people.AsParallel()
                         where person.City == "Seattle"
                         select person;
            foreach (var person in persons) Console.WriteLine(person.Name);
            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
            Console.Clear();
            #endregion

        }
    }
}
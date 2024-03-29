﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Parallelization
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

        public static bool CheckCity(string name)
        {
            if (name == string.Empty) {
                throw new ArgumentException("Name should not be empty");
            }
            return name == "Seattle";
        }

        class Person
        {
            public string Name { get; set; }
            public string City { get; set; }
        }
        static void Main(string[] args)
        {
            //#region Parallel
            //Console.WriteLine("Parallel : ");
            //Parallel.Invoke(() => Task1(), () => Task2());
            //Console.WriteLine("Finished processing. Press a key to end.");
            //Console.ReadKey();
            //Console.Clear();
            //#endregion

            var items = Enumerable.Range(0, 10);

            //#region Parallel - ForEach
            //Console.WriteLine("Parallel - ForEach : ");
            //Parallel.ForEach(items, item =>
            //{
            //    WorkOnItem(item);
            //});

            //Console.WriteLine("Finished processing. Press a key to end.");
            //Console.ReadKey();
            //Console.Clear();
            //#endregion

            //#region Parallel - For
            //Console.WriteLine("Parallel - For : ");
            //var itemsArr = items.ToArray();
            //Parallel.For(0, itemsArr.Length, i =>
            //{
            //    WorkOnItem(itemsArr[i]);
            //});
            //Console.WriteLine("Finished processing. Press a key to end.");
            //Console.ReadKey();
            //Console.Clear();
            //#endregion

            //#region Managing Parallel For and Parallel Foreach
            //Console.WriteLine("Managing Parallel For and Parallel Foreach : ");
            //ParallelLoopResult result = Parallel.For(0, itemsArr.Count(), (int i, ParallelLoopState loopState) =>
            //{
            //    if (i == 7) loopState.Break();
            //    WorkOnItem(itemsArr[i]);
            //});
            //Console.WriteLine($"Completed: {result.IsCompleted}");
            //Console.WriteLine($"Items: {result.LowestBreakIteration}");
            //Console.WriteLine("Finished processing. Press a key to end.");
            //Console.ReadKey();
            //Console.Clear();
            //#endregion

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
                    new Person{Name="James", City="London"},
                    new Person{Name="Heitor", City=""},
                    new Person{Name="Arthur", City=""}
            };

            //#region Parallel LINQ
            //Console.WriteLine("Parallel LINQ : ");
            //var persons = from person in people.AsParallel()
            //             where person.City == "Seattle"
            //             select person;
            //foreach (var person in persons) Console.WriteLine(person.Name);
            //Console.WriteLine("Finished processing. Press a key to end.");
            //Console.ReadKey();
            //Console.Clear();
            //#endregion

            //#region Informing Parallelization
            //Console.WriteLine("Informing Parallelization : ");
            ///*This call of AsParallel requests that the query be parallelized wheter performance is improved or not, 
            //with the request that the query be executed on a maximum of four processors*/
            //var informingResult = from person in people.AsParallel()
            //                      .WithDegreeOfParallelism(4)
            //                      .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
            //                      where person.City == "Seattle"
            //                      select person;

            ////AsOrdered
            //Console.WriteLine("AsOrdered : ");
            ///*This AsOrdered method does not prevent the parallelization of the query. Instead it organizes the output 
            // so that it is in the same order as the oprginal data. It can slow down the query*/

            //var orderedPersons = from person in people.AsParallel()
            //              .AsOrdered()
            //              where person.City == "Seattle"
            //              select person;
            //foreach (var person in orderedPersons) Console.WriteLine(person.Name);
            //Console.WriteLine("Finished processing. Press a key to end.");
            //Console.ReadKey();
            //Console.Clear();


            ////AsSequential
            //Console.WriteLine("AsSequential : ");
            //var asSequentialResult = (from person in people.AsParallel()
            //                          where person.City == "Seattle"
            //                          orderby (person.Name)
            //                          select new
            //                          {
            //                              Name = person.Name
            //                          }).AsSequential().Take(4);
            //foreach (var person in asSequentialResult) Console.WriteLine(person.Name);
            //Console.WriteLine("Finished processing. Press a key to end.");
            //Console.ReadKey();
            //Console.Clear();
            //#endregion

            //#region Interating query using ForAll
            //Console.WriteLine("Interating query using ForAll : ");
            //var interatingResult = from person in people.AsParallel()
            //                       where person.City == "Seattle"
            //                       select person;
            //interatingResult.ForAll(person => Console.WriteLine(person.Name));
            //Console.WriteLine("Finished processing. Press a key to end.");
            //Console.ReadKey();
            //Console.Clear();
            //#endregion

            //#region Exceptions in queries
            //try
            //{
            //    var result = from person in people.AsParallel()
            //                 where CheckCity(person.City)
            //                 select person;
            //    result.ForAll(person => Console.WriteLine(person.Name));
            //}
            //catch (AggregateException aggExc)
            //{
            //    Console.WriteLine($"{aggExc.InnerExceptions.Count} were thrown");
            //    foreach (var ex in aggExc.InnerExceptions)
            //    {
            //        Console.WriteLine($"Message : {ex.Message}");
            //    }
            //}
            //Console.WriteLine("Finished processing. Press a key to end.");
            //Console.ReadKey();
            //Console.Clear();
            //#endregion

        }
    }
}

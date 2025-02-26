using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab12
{
    internal class Program
    {

        // Zadanie 1
        //public static void Main()
        //{
        //    try
        //    {
        //        new Thread(Run).Start();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception!");
        //    }
        //    Console.ReadKey();
        //}
        //static void Run() { throw null; } // Throws a NullReferenceException

        // Zadanie 2
        //public static void Main()
        //{
        //    new Thread(Run).Start();
        //    Console.ReadKey();
        //}
        //static void Run()
        //{
        //    try
        //    {
        //        // ...
        //        throw null;
        //        // ...
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception!");
        //    }
        //}

        // Zadanie 3
        //static void Main()
        //{
        //    Task.Factory.StartNew(Run);
        //    Console.ReadKey();
        //}
        //static void Run()
        //{
        //    Console.WriteLine("Hello !! The thread pool!");
        //}

        // Zadanie 4
        //static void Main()
        //{
        //    ThreadPool.QueueUserWorkItem(Run);
        //    ThreadPool.QueueUserWorkItem(Run, 123);
        //    Console.ReadLine();
        //}
        //static void Run(object data)
        //{
        //    Console.WriteLine("Hello !! The thread pool! " + data);
        //}

        // Zadanie 5
        //static void Main()
        //{
        //    Func<string, int> method = Do;
        //    IAsyncResult cookie = method.BeginInvoke("test", null, null);
        //    // .. tutaj możemy równolegle wykonywać inne prace ...
        //    int result = method.EndInvoke(cookie);
        //    Console.WriteLine("String length is: " + result);
        //    Console.ReadKey();
        //}
        //static int Do(string s) { return s.Length; }

    }
}

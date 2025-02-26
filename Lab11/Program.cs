using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab11
{
    // Zadanie 1
    //class ThreadExample
    //{
    //    static void Main()
    //    {
    //        Thread t = new Thread(Write1); //Uruchom inny wątek
    //        t.Start();
    //        // Główny wątek.
    //        for (int i = 0; i < 1000; i++) Console.Write("0");
    //        Console.ReadKey();
    //    }
    //    //Inny wątek
    //    static void Write1()
    //    {
    //        for (int i = 0; i < 1000; i++) Console.Write("1");
    //    }
    //}


    // Zadanie 2
    //internal class Program
    //{
    //    static void Main()
    //    {
    //        new Thread(Run).Start(); // Uruchom Run w innym wątku
    //        Run(); // Uruchom Run w głownym wątku
    //        Console.ReadKey();
    //    }
    //    static void Run()
    //    {
    //        // Deklaracja i użycie zmiennej lokalnej - 'cycles'
    //        for (int cycles = 0; cycles < 5; cycles++) Console.Write('x');
    //    }
    //}


    // Zadanie 3
    //class ThreadTest
    //{
    //    bool done;
    //    static void Main()
    //    {
    //        ThreadTest tt = new ThreadTest();
    //        new Thread(tt.Run).Start();
    //        tt.Run();
    //        Console.ReadKey();
    //    }
    //    // Zauważ, że Run jest teraz metodą instancji
    //    void Run()
    //    {
    //        if (!done) { done = true; Console.WriteLine("Done"); }
    //    }
    //}


    // Zadanie 4
    //class ThreadExample
    //{
    //    static bool done; // Pole statyczne
    //    static void Main()
    //    {
    //        new Thread(Run).Start();
    //        Run();
    //        Console.ReadKey();
    //    }
    //    //static void Run()
    //    //{
    //    //    if (!done) { done = true; Console.WriteLine("Done"); }
    //    //}
    //    static void Run()
    //    {
    //        if (!done) { Console.WriteLine("Done"); done = true; }
    //    }
    //}


    // Zadanie 5
    //class ThreadExample
    //{
    //    static bool done; // Pole statyczne
    //    static readonly object locker = new object();
    //    static void Main()
    //    {
    //        new Thread(Run).Start();
    //        Run();
    //        Console.ReadKey();
    //    }

    //    static void Run()
    //    {
    //        lock (locker)
    //        {
    //            if (!done) { done = true; Console.WriteLine("Done"); }
    //        }
    //    }
    //}


    // Zadanie 6
    //internal class Program
    //{
    //    static void Main()
    //    {
    //        Thread t = new Thread(Run);
    //        t.Start();
    //        t.Join();
    //        Console.WriteLine("Thread t has ended!");
    //        Console.ReadKey();
    //    }
    //    static void Run()
    //    {
    //        for (int i = 0; i < 777; i++) Console.Write("J");
    //    }
    //}


    // Zadanie 7
    //internal class Program
    //{
    //    static readonly object locker = new object();
    //    static void Main()
    //    {
    //        int[,] matrix1 = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
    //        int[,] matrix2 = { { 2, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 } };
    //        int[,] matrix3 = { { 3, 3, 3 }, { 3, 3, 3 }, { 3, 3, 3 } };
    //        int[,] matrix4 = { { 4, 4, 4 }, { 4, 4, 4 }, { 4, 4, 4 } };
    //        int[,] matrix5 = { { 5, 5, 5 }, { 5, 5, 5 }, { 5, 5, 5 } };

    //        List<int[,]> matrices = new List<int[,]> { matrix1, matrix2, matrix3, matrix4, matrix5 };
    //        List<string> matricesName = new List<string> { "matrix1", "matrix2", "matrix3", "matrix4", "matrix5" };
    //        List<Thread> threads = new List<Thread>();

    //        for (int i = 0; i < matrices.Count(); i++)
    //        {
    //            int[,] matrixCopy = (int[,])matrices[i].Clone();
    //            string matrixNameCopy = (string)matricesName[i].Clone();
    //            Thread t = new Thread(() => Add1(matrixCopy, matrixNameCopy));
    //            threads.Add(t);
    //            t.Start();
    //        }

    //        foreach (var t in threads)
    //        {
    //            t.Join();
    //        }
    //        Console.ReadKey();
    //    }
    //    static void Add1(int[,] matrix, string matrixName)
    //    {
    //        int sum = 0;
    //        for (int i = 0; i < matrix.GetLength(0); i++)
    //        {
    //            for (int j = 0; j < matrix.GetLength(1); j++)
    //            {
    //                sum += matrix[i, j];
    //            }
    //        }
    //        lock (locker) { Console.WriteLine("Wynik dla " + matrixName + ": " + sum); }
    //    }
    //}


}

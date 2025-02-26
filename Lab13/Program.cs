//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LAb13
//{
//    public struct authorParam
//    {
//        public string id;
//        public double book;
//        public int year;
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            //Zadanie1
//            //List<authorParam> mAuthors;
//            //mAuthors = new List<authorParam>();

//            //var el1 = new authorParam { id = "111", book = 111, year = 2021 };
//            //var el2 = new authorParam { id = "222", book = 222, year = 2022 };
//            //var el3 = new authorParam { id = "333", book = 333, year = 2023 };

//            //mAuthors.Add(el1);
//            //mAuthors.Add(el2);
//            //mAuthors.Add(el3);

//            //mAuthors[1].year = 2020;


//            //Zadanie3
//            //List<string> values = new List<string>() { "Ala ", "ma ", "kota ", "!" };
//            //string output = string.Empty;
//            //foreach (var value in values)
//            //{
//            //    output += value; // ç ???
//            //}
//            //Console.WriteLine(output);
//            //Console.ReadKey();
//        }
//    }
//}

//Zadanie4
//using System;
//using System.Drawing;
//namespace ConsoleApp1
//{
//    class Program
//    {
//        static Point point1;
//        static Pen pen1;
//        static void Main(string[] args)
//        {
//            Console.WriteLine(pen1 == null);
//            Console.WriteLine(point1 == null);
//            Console.ReadKey();
//        }
//    }
//}


//Zadanie7
using System;
using System.Collections.Generic;
class Program
{
    private static IEnumerable<string> _numbers = new[] { "1", "2", "3", "4" };
    static void Main(string[] args)
    {
        Console.WriteLine("Classic:");
        foreach (var fruit in GetFruits())
        {
            Console.WriteLine(fruit);
        }
        Console.WriteLine("\r\nYield return:");
        foreach (var fruit in GetFruitsWithYield())
        {
            Console.WriteLine(fruit);
        }
        Console.ReadKey();
    }
    private static IEnumerable<string> GetFruits()
    {
        var result = new List<string>();
        foreach (var num in _numbers)
        {
            if (num == "3" || num == "4")
            {
                result.Add(num);
            }
        }
        return result;
    }
    private static IEnumerable<string> GetFruitsWithYield()
    {
        foreach (var num in _numbers)
        {
            if (num == "3" || num == "4")
            {
                yield return num;
            }
        }
    }
}

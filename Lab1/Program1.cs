using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomasz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj liczbę:");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Twoja liczba: " + x);
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab10
{
    internal class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            Task1();
            Console.ReadLine();
        }

        public static void Task1()
        {
            Thread t = new Thread(new ThreadStart(ThreadProc));
            t.Start();
            t.Join();
            
            Console.WriteLine();
            Console.WriteLine("---  Choinka  ---");
        }

        public static void ThreadProc()
        {
            int treeHeight = 21;
            int trunkHeight = 4;
            int trunkWidth = 5;

            for (int i = 1; i <= treeHeight; i++)
            {
                for (int j = 0; j < treeHeight - i; j++)
                {
                    Console.Write(" ");
                }

                for (int k = 0; k < 2 * i - 1; k++)
                {
                    char symbol = random.NextDouble() < 0.3 ? 'o' : (random.NextDouble() < 0.2 ? '.'
                        : (random.NextDouble() < 0.1 ? '^' : '*'));
                    Console.Write(symbol);
                }

                Console.WriteLine();
            }

            for (int i = 0; i < trunkHeight; i++)
            {
                for (int j = 0; j < ((treeHeight*2-1) - trunkWidth)/2; j++)
                {
                    Console.Write(" ");
                }

                for (int k = 0; k < trunkWidth; k++)
                {
                    Console.Write("M");
                }

                Console.WriteLine();
            }
        }
    }
}

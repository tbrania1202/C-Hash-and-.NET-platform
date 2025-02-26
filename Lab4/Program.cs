using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Zadanie 1
            //PassingParameters();

            //  Zadanie 2
            Memory();

            //  Zadanie 3
            //Array1();

            //  Zadanie 4
            //Array2();

            //  Zadanie 5
            //Array3();

            //  Zadanie 6
            //Array4();

            //  Zadanie 7
            //Array5();

            //  Zadanie 8
            //Array6();

            Console.ReadLine();
        }

        public class Point
        {
            public int x, y;
            public Point(int p1, int p2)
            {
                x = p1;
                y = p2;
            }
        }
        static void PassingParameters()
        {
            Console.WriteLine("Zadanie 1");
            //void Fun1(in int i)
            //{
            //    i = 3;
            //}
            void Fun2(out int i)
            {
                i = 3;
            }
            void Fun3(ref int i)
            {
                i = 3;
            }
            void Fun4(int i)
            {
                i = 3;
            }

            Console.WriteLine("Błąd przy modyfikacji argumentu in");

            int x = 0;
            Console.WriteLine("Początkowa zmienna: {0}", x);
            Fun2(out x);
            Console.WriteLine("Zmienna po modyfikacji Fun2 (out): {0}", x);

            x = 0;
            Console.WriteLine("Początkowa zmienna: {0}", x);
            Fun3(ref x);
            Console.WriteLine("Zmienna po modyfikacji Fun3 (ref): {0}", x);

            x = 0;
            Console.WriteLine("Początkowa zmienna: {0}", x);
            Fun4(x);
            Console.WriteLine("Zmienna po modyfikacji Fun4: {0}", x);

            short y = 1;
            //Fun2(out y);
            //Fun3(ref y);
            Console.WriteLine("Błąd przekonwertowania pomiędzy short a int dla Fun2 i Fun3");
            Console.WriteLine("Początkowa zmienna: {0}", y);
            Fun4(y);
            Console.WriteLine("Zmienna short po modyfikacji Fun4: {0}", y);

            //void Fun2(in int i)
            //{
            //    i = 3;
            //}
            Console.WriteLine("Nie jest możliwe utworzenie dwóch metod (z in i out) o tej samej nazwie w obrębie jednej klasy");


            void Fun5(Point p)
            {
                Point p1 = new Point(3,3);
                p = p1;
            }

            void Fun6(ref Point p)
            {
                Point p1 = new Point(3, 3);
                p = p1;
            }

            Point point = new Point(1, 1);

            Console.WriteLine("\nPoczątkowy punkt: {0} {1}", point.x, point.y);
            Fun5(point);
            Console.WriteLine("Punkt po wykonaniu Fun5: {0} {1}", point.x, point.y);

            Console.WriteLine("Początkowy punkt: {0} {1}", point.x, point.y);
            Fun6(ref point);
            Console.WriteLine("Punkt po wykonaniu Fun6: {0} {1}", point.x, point.y);

            void Fun7(Point p)
            {
                p = null;
            }

            void Fun8(ref Point p)
            {
                p = null;
            }

            point.x = 1;
            point.y = 1;
            Console.WriteLine("\nPoczątkowy punkt: {0} {1}", point.x, point.y);
            Fun7(point);
            Console.WriteLine("Punkt po wykonaniu Fun7: {0} {1}", point.x, point.y);

            Console.WriteLine("Początkowy punkt: {0} {1}", point.x, point.y);
            Fun8(ref point);
            Console.WriteLine("Wynik wypisanie Fun8: Odwołanie do obiektu nie zostało ustawione na wystąpienie obiektu.");
        }

        class TestPointer
        {
            public unsafe static void Memory1()
            {
                int[] list = { 10, 100, 200 };
                fixed (int* ptr = list)

                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine("Adres [{0}]={1}", i, (int)(ptr + i));
                        Console.WriteLine("Wartość[{0}]={1}", i, *(ptr + i));
                    }
                //Console.ReadKey();
            }

            public unsafe static void swap(int* p, int* q)
            {
                int temp = *p;
                *p = *q;
                *q = temp;
            }

            public unsafe static void Allocation()
            {
                int[] array = new int[1024];
                fixed (int* buf = array)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        *(buf + 1) = i + 1;
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Zmienna {0} po zwiększeniu o 1: {1}", i, array[i]);
                }
            }


        }

        static unsafe void Memory()
        {
            Console.WriteLine("Zadanie 2");
            TestPointer.Memory1();
            Console.WriteLine("Po usunięciu modyfikatora unsafe pojawił się błąd kompilacji");

            int x = 5;
            int y = 2;
            Console.WriteLine("\nPoczątkowe zmienne: {0} {1}", x, y);
            TestPointer.swap(p: &x, q: &y);
            Console.WriteLine("Zmienne po funckji swap: {0} {1}\n", x, y);
            TestPointer.Allocation();
        }   

        static void Array1()
        {
            Console.WriteLine("Zadanie 3");
            string[] elements = new string[10];
            Console.WriteLine("Tablica początkowa");
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = $"el{i + 1}";
                Console.Write(elements[i] + " ");
            }

            Console.WriteLine("\nPodaj element: ");
            string x = Console.ReadLine();
            for (int i = elements.Length - 2; i >= 0; i--)
            {
                elements[i+1] = elements[i];
            }
            elements[0] = x;

            Console.WriteLine("Tablica końcowa");
            for (int i = 0; i < elements.Length; i++)
            {
                Console.Write(elements[i] + " ");
            }
        }

        static void Array2()
        {
            Console.WriteLine("Zadanie 4");

            int[] arr = new int[5];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Podaj cyfrę: ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write(arr[i] + " ");
            }
        }

        static void Array3()
        {
            Console.WriteLine("Zadanie 5");
            int[] arr = new int[5];
            arr[0] = 2;
            arr[1] = 4;
            arr[2] = 2;
            arr[3] = 4;
            arr[4] = 4;
            int duplicates = 0;

            var dict = new Dictionary<int, int>();

            foreach (int i in arr) 
            {
                if (dict.ContainsKey(i))
                {
                    dict[i]++;
                }
                else
                {
                    dict[i] = 1;
                }
            }

            foreach (var key in dict)
            {
                if (key.Value > 1)
                {
                    duplicates++;
                }
            }

            Console.WriteLine("Tablica:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\nIlość powtarzających sie liczb: {0}", duplicates);
        }

        static void Array4()
        {
            Console.WriteLine("Zadanie 6");
            int[,] arr1 = new int[5, 5];
            int[,] arr2 = new int[5, 5];
            int[,] arr = new int[5, 5];

            Console.WriteLine("Macierz wynikowa:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr1[i, j] = i;
                    arr2[i, j] = j;
                    arr[i, j] = arr1[i, j] + arr2[i, j];
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nLength: {0}", arr.Length);
            Console.WriteLine("LongLength: {0}", arr.LongLength);
            Console.WriteLine("Rank: {0}", arr.Rank);
        }

        static void Array5()
        {
            Console.WriteLine("Zadanie 7");
            int[,] arr = new int[3, 3]
            {
                { 1, 0, -1},
                { 0, 0, 1},
                { -1, -1, 0}
            };

            double det = arr[0,0]*arr[1,1]*arr[2,2] + arr[0,1]*arr[1,2]*arr[2,0] + arr[0,2]*arr[1,0]*arr[2,1] - arr[2,0]*arr[1,1]*arr[0,2] - arr[0,0]*arr[1,2]*arr[2,1] - arr[0,1]*arr[1,0]*arr[2,2];
            Console.WriteLine("Wyznacznik: {0}", det);
        }

        static void Array6()
        {
            Console.WriteLine("Zadanie 8");
            int[,] arr = new int[5, 6]
            {
                { 1, 2, 3, 0, 0, 0},
                { 4, 5, 6, 7, 8, 9},
                { 10, 11, 12, 13, 0, 0},
                { 14, 15, 16, 17, 18, 0},
                { 19, 20, 21, 0, 0, 0}
            };

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] != 0)
                    {
                        Console.Write(arr[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            int[][] arr1 = new int[][]
            {
                new int[] { 1, 2, 3},
                new int[] {4, 5, 6, 7, 8, 9},
                new int[] {10, 11, 12, 13},
                new int[] {14, 15, 16, 17, 18},
                new int[] {19, 20, 21}
            };

            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr1[i].Length; j++)
                {
                    Console.Write(arr1[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

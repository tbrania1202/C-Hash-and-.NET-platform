using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Zadanie 1
            //Structure1();

            // Zadanie 2
            //Structure2();

            // Zadanie 3
            //ValueTypes();

            // Zadanie 4
            //EnumType();

            // Zadanie 5
            //Chars();

            // Zadanie 6
            //StringType();

            // Zadanie 7
            //Overflow();

            // Zadanie 8
            //ReferenceTypes();

            // Zadanie 9
            //Calculator();

            // Zadanie 10
            //Conversion();

            Console.ReadLine();
        }

        struct Point2D
        {
            private double x;
            private double y;

            public Point2D(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public double X
            {
                get { return this.x; }
                set { this.x = value; }
            }

            public double Y
            {
                get { return this.y; }
                set { this.y = value; }
            }

            public void Reset()
            {
                this.x = 0;
                this.y = 0;
            }

            public void IncrX(double i)
            {
                this.x += i;
            }

            public void IncrY(double i)
            { 
                this.y += i;
            }

            public void Print2DPoint()
            {
                Console.WriteLine("x = {0} y = {1}", this.x, this.y);
            }

            public double Dist(Point2D point)
            {
                double dist = Math.Sqrt(Math.Pow(point.X - this.x, 2) + Math.Pow(point.Y - this.y, 2));
                return dist;
            }
        }

        static void Structure1()
        {
            Console.WriteLine("Zadanie 1");
            Console.WriteLine("Podaj wartość promienia:");
            double rad = double.Parse(Console.ReadLine());

            List<Point2D> lst = new List<Point2D>();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(string.Format("({0}) Podaj x", i + 1));
                double x = double.Parse(Console.ReadLine());
                Console.WriteLine(string.Format("({0}) Podaj y", i + 1));
                double y = double.Parse(Console.ReadLine());
                Point2D point2D = new Point2D(x, y);
                point2D.Print2DPoint();
                lst.Add(point2D);
            }

            bool show = false;
            while (!show)
            {
                double minDist = lst[0].Dist(lst[lst.Count - 1]);
                int idx = 1;
                foreach (Point2D point in lst.Take(lst.Count - 1).ToList())
                {
                    double currentDist = point.Dist(lst[lst.Count - 1]);

                    if (point.X < 0 || point.Y < 0 || lst[lst.Count-1].X < 0 || lst[lst.Count-1].Y < 0)
                    {
                        Console.WriteLine("Podany punkt ma ujemną współrzędną");
                        show = true;
                        break;
                    }
                    else if (currentDist < rad)
                    {
                        show = true;
                        Console.WriteLine("Punkt leży wewnątrz okręgu o promieniu: {0}", rad);
                        break;
                    }
                    else
                    {
                        if (currentDist < minDist)
                        {
                            minDist = currentDist;
                        }
                        if (idx == lst.Count-1)
                        {
                            Console.WriteLine("Dystans od najbiższego punktu: {0}", minDist);
                            Console.WriteLine("Podaj nowy x");
                            double x = double.Parse(Console.ReadLine());
                            Console.WriteLine("Podaj nowy y");
                            double y = double.Parse(Console.ReadLine());
                            Point2D point2D = new Point2D(x, y);
                            point2D.Print2DPoint();
                            lst[lst.Count - 1] = point2D;
                        }
                        idx += 1;
                    }
                }
            }

            if (show)
            {
                Console.WriteLine("Wprowadzone punkty:");
                foreach (Point2D point in lst)
                {
                    point.Print2DPoint();
                }
            }
        }

        struct Point2D_v1
        {
            private double x;
            private double y;

            public double X
            {
                get { return this.x; }
                set { this.x = value; }
            }

            public double Y
            {
                get { return this.y; }
                set { this.y = value; }
            }

            public void Print2DPoint()
            {
                Console.WriteLine("x = {0} y = {1}", this.x, this.y);
            }
        }

        struct Point2D_v2
        {
            double x;
            double y;

            public Point2D_v2(double x, double y) // brak parametrów oraz inicjalizacji powoduje błąd
            {
                this.x = 3;
                this.y = 3;
            }

            public double X
            {
                get { return this.x; }
                set { this.x = value; }
            }

            public double Y
            {
                get { return this.y; }
                set { this.y = value; }
            }

            public void Print2DPoint()
            {
                Console.WriteLine("x = {0} y = {1}", this.x, this.y);
            }
        }

        static void Structure2()
        {
            Console.WriteLine("Zadanie 2");

            Point2D_v1 point2D_v1;
            //point2D_v1.ToString(); // powoduje błąd

            Point2D_v1 point2D_v11 = new Point2D_v1();
            point2D_v11.Print2DPoint();

            // konstruktor bezparametrowy nie jest możliwy do zrealizowania w obecnej wersji języka C#

            // inicjalizacja nie rozwiązuje problemu braku parametryzacji konstruktora

            // Struktura z zadania 1 prezentuje prywatne współrzędne punktów, konstruktor parametrowy wraz z inicjalizacją (dynamiczną) wartości punktów:
            Point2D correct_point = new Point2D(5, 7);
            correct_point.Print2DPoint();
        }


        static void ValueTypes()
        {
            Console.WriteLine("Zadanie 3");
            int n_int = 0;
            int n_float = 0;
            int n_string = 0;
            while (true)
            {
                Console.WriteLine("Podaj string, int lub float");
                string x = Console.ReadLine();
                if (x == "-1")
                {
                    break;
                }
                else if (int.TryParse(x, out _))
                {
                    n_int++;
                }
                else if (float.TryParse(x, out _))
                {
                    n_float++;
                }
                else
                {
                    n_string++;
                }
            }
            Console.WriteLine("Ilość int: {0}", n_int);
            Console.WriteLine("Ilość float: {0}", n_float);
            Console.WriteLine("Ilość string: {0}", n_string);

        }

        enum Day
        {
            Poniedziałek = 1,
            Wtorek = 2,
            Środa = 3,
            Czwartek = 4,
            Piątek = 5,
            Sobota = 6,
            Niedziela = 7
        }

        enum Value
        {
            Mała,
            Średnia,
            Duża
        }

        static void EnumType()
        {
            Console.WriteLine("Zadanie 4");
            Console.WriteLine("Podaj dzień tygodnia (1-7)");
            int n = int.Parse(Console.ReadLine());
            Day day = (Day)n;
            Console.WriteLine("Podałeś: {0}", day);

            Console.WriteLine("\nPodaj liczbę");
            int x = int.Parse(Console.ReadLine());
            Value val = x < 10 ? Value.Mała : x < 100 ? Value.Średnia : Value.Duża;
            Console.WriteLine("Twoja liczba jest: {0}", val);
        }


        enum Vowels
        {
            a, ą, e, ę, i, o, u, y
        }

        static void Chars()
        {
            Console.WriteLine("Zadanie 5");
            Console.WriteLine("Podaj jeden znak");
            string c = Console.ReadLine();
            if (Enum.IsDefined(typeof(Vowels), c))
            {
                Console.WriteLine("Podałeś samogłoskę");
            }
            else if (int.TryParse(c, out _))
            {
                Console.WriteLine("Podałeś cyfrę");
            }
            else
            {
                Console.WriteLine("Podałeś znak inny niż samogłoska i cyfra");
            }

        }

        static void StringType()
        {
            Console.WriteLine("Zadanie 6");
            Console.WriteLine("Podaj łańcuch znaków");
            string txt = Console.ReadLine();
            string newtxt = "";
            for (int i = 0; i < txt.Length - 1 ; i++)
            {
                newtxt += txt[i] + " ";
            }
            newtxt += txt[txt.Length - 1];
            Console.WriteLine(newtxt);
        }

        static void Overflow()
        {
            Console.WriteLine("Zadanie 7");

            //Overflow during compilation
            //checked
            //{
            //   int x = int.MaxValue + 1;
            //}

            // Overflow during program executing
            int y = int.MaxValue;
            checked
            {
                y++;
            }
        }

        public struct Coords
        {
            public int x, y;
            public Coords(int p1, int p2)
            {
                x = p1;
                y = p2;
            }
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

        static void Fun1(Point p)
        {
            p.x++;
            p.y++;
        }

        static void Fun2(Coords c)
        {
            c.x++;
            c.y++;
        }

        static void ReferenceTypes()
        {
            Console.WriteLine("Zadanie 8");
            Coords coords = new Coords(0, 0);
            Point point = new Point(0, 0);

            Console.WriteLine("Coords(struktura) przed: {0} {1}", coords.x, coords.y);
            Console.WriteLine("Point(klasa) przed: {0} {1}", point.x, point.y);

            Fun1(point);
            Fun2(coords);

            Console.WriteLine("Coords(struktura) po: {0} {1}", coords.x, coords.y);
            Console.WriteLine("Point(klasa) po: {0} {1}", point.x, point.y);


            Coords c1 = new Coords(1, 1);
            Coords c2 = new Coords(1, 1);
            Point p1 = new Point(1, 1);
            Point p2 = new Point(1, 1);

            Console.WriteLine("\nStruktura Coords:");
            Console.WriteLine("Object.Equals(c1, c1): {0}", Object.Equals(c1, c2));
            Console.WriteLine("c1.Equals(c2): {0}", c1.Equals(c2));
            Console.WriteLine("Object.ReferenceEquals(c1, c2): {0}", Object.ReferenceEquals(c1, c2));

            Console.WriteLine("\nKlasa Point");
            Console.WriteLine("Object.Equals(p1, p2): {0}", Object.Equals(p1, p2));
            Console.WriteLine("p1.Equals(p2): {0}", p1.Equals(p2));
            Console.WriteLine("Object.ReferenceEquals(p1, p2): {0}", Object.ReferenceEquals(p1, p2));
        }

        static void Calculator()
        {
            Console.WriteLine("Zadanie 9");
            Console.WriteLine("Podaj działanie");
            string txt = Console.ReadLine();
            int result = 0;
            int operation = 1;
            int number = 0;
            foreach (char ch in txt)
            {
                if (!char.IsDigit(ch) && ch != '+' && ch != '-')
                {
                    Console.WriteLine("Błąd formatu danych wejściowych");
                    break;
                }
                else if (char.IsDigit(ch))
                {
                    number = 10*number + (int)char.GetNumericValue(ch);
                }
                else if (ch == '+')
                {
                    result += operation * number;
                    operation = 1;
                    number = 0;
                }

                else if (ch == '-')
                {
                    result += operation * number;
                    operation = -1;
                    number = 0;
                }
            }
            result += operation * number;

            Console.WriteLine("Wynik: {0}", result);
        }
        static void Conversion()
        {
            Console.WriteLine("Zadanie 10");
            Console.WriteLine("Konwersje niejawne (implicite)");
            int int_number = 37;
            long long_number = int_number;
            Console.WriteLine(long_number);

            float float_number = 5.45f;
            double double_number = float_number;
            Console.WriteLine(double_number);

            byte bytes = 100;
            int int_number2 = bytes;
            Console.WriteLine(int_number2);

            int int_number3 = 33;
            float float_number2 = int_number3;
            Console.WriteLine(float_number2);

            Console.WriteLine("\nKonwersje jawne (explicite)");
            string string_number = "33";
            int int_number4 = int.Parse(string_number);
            Console.WriteLine(int_number4);

            long long_number2 = 1234567;
            int int_number5 = (int)long_number2;
            Console.WriteLine(int_number5);

            double double_number2 = 4.789;
            float float_number3 = (float)double_number2;
            Console.WriteLine(float_number3);

            double double_number3 = 3.1;
            int int_number6 = (int)double_number3;
            Console.WriteLine(int_number6);
        }
    }

}

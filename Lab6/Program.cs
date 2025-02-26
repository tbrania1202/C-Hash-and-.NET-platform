using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab6.Program;

namespace Lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Zadanie 1
            Task1();
            Console.WriteLine();

            //Zadanie 2
            Task2();
            Console.WriteLine();

            //Zadanie 3
            Task3();
            Console.WriteLine();

            //Zadanie 4
            Task4();
            Console.WriteLine();

            //Zadanie 5
            Task5();
            Console.WriteLine();

            Console.ReadKey();
        }

        public class Tree
        {
            protected string _name;
            protected int _age;

            public Tree(string name, int age)
            {
                _name = name;
                _age = age;
            }

            public string Name { get { return _name; } set { } }
            public int Age { get { return _age; } }
        }

        public class Fir : Tree 
        {
            protected List<Bauble> _baubles;

            public Fir(string name, int age) : base(name, age)
            {
                _baubles = new List<Bauble>();
            }

            protected class Bauble
            {
                protected string _color;
                protected string _type;

                public Bauble(string color, string type)
                {
                    _color = color;
                    _type = type;
                }

                public string Color { get { return _color; } set { _color = value; } }
                public string Typee { get { return _type; } set { _type = value; } }
            }

            public void Add(string color, string type)
            {
                Bauble bauble = new Bauble(color, type);
                _baubles.Add(bauble);
            }

            public void Remove(int idx)
            {
                _baubles.RemoveAt(idx);
            }
        }

        public class ChristmasTree : Fir
        {
            public ChristmasTree(string name, int age) : base(name, age) { }

            public virtual string this[int idx]
            {
                get
                {
                    return _baubles[idx].Color;
                }
                set
                {
                    _baubles[idx].Color = value;
                }
            }

            public int this[string color]
            {
                get
                {
                    return _baubles.Where(b => b.Color == color).ToList().Count();
                }
            }
        }

        static void Task1()
        {
            Console.WriteLine("Zadanie 1");

            ChristmasTree christmasTree1 = new ChristmasTree("Xmas Tree", 15);
            christmasTree1.Add("Yellow", "Star");
            christmasTree1.Add("Red", "Ball");
            christmasTree1.Add("Red", "Bell");
            christmasTree1.Add("Blue", "Angel");
            christmasTree1.Add("Blue", "Ball");

            Console.WriteLine($"Christmas Tree: {christmasTree1.Name}, age: {christmasTree1.Age}");
            Console.WriteLine($"Bauble[2] color: {christmasTree1[2]}");

            Console.WriteLine($"Number of Yellow Baubles: {christmasTree1["Yellow"]}");
            Console.WriteLine($"Number of Red Baubles: {christmasTree1["Red"]}");

            Console.WriteLine($"Bauble[0] color: {christmasTree1[0]}");
            christmasTree1[0] = "Purple";
            Console.WriteLine($"Bauble[0] color after change: {christmasTree1[0]}");

            Console.WriteLine($"Number of Blue Baubles: {christmasTree1["Blue"]}");
            christmasTree1.Remove(3);
            Console.WriteLine($"Number of Blue Baubles after remove operation: {christmasTree1["Blue"]}");
        }

        public class ChristmasTreeA : ChristmasTree
        {
            public ChristmasTreeA(string name, int age) : base(name, age) { }

            public override string this[int idx]
            {
                get
                {
                    return _baubles[idx].Typee;
                }
                set
                {
                    _baubles[idx].Typee = value;
                }
            }

            public string BaubleColor(int idx)
            {
                return base[idx];
            }
        }

        static void Task2()
        {
            Console.WriteLine("Zadanie 2");

            ChristmasTreeA christmasTreeA = new ChristmasTreeA("Xmas Tree A", 12);
            christmasTreeA.Add("Yellow", "Star");
            Console.WriteLine($"Wynik indeksora w klasie ChristmassTreeA: { christmasTreeA[0]}");

            ChristmasTree christmasTree1 = (ChristmasTree)christmasTreeA;
            Console.WriteLine($"Wynik indeksora po rzutowaniu na klasę ChristmassTree: {christmasTree1[0]}");

            Console.WriteLine($"Funckja BaubleColor[0]: {christmasTreeA.BaubleColor(0)}");
        }

        public class ChristmasTreeB : ChristmasTreeA
        {
            public ChristmasTreeB(string name, int age) : base(name, age) { }

            public new string this[int idx]
            {
                get
                {
                    string color = _baubles[idx].Color;
                    string type = base[idx];
                    return $"{color}_{type}";
                }
            }
        }

        static void Task3()
        {
            Console.WriteLine("Zadanie 3");

            ChristmasTreeB christmasTreeB = new ChristmasTreeB("Xmas Tree B", 10);
            christmasTreeB.Add("Red", "Ball");
            Console.WriteLine($"Wynik indeksora w klasie ChristmassTreeB: {christmasTreeB[0]}");

            ChristmasTreeA christmasTreeA1 = (ChristmasTreeA)christmasTreeB;
            Console.WriteLine($"Wynik indeksora po rzutowaniu na klasę ChristmassTreeA: {christmasTreeA1[0]}");
        }

        public sealed class ChristmasTreeC : ChristmasTreeB
        {
            public ChristmasTreeC(string name, int age) : base(name, age) { }
        }

        //public class ChristmasTreeD : ChristmasTreeC
        //{
        //    public ChristmasTreeD(string name, int age) : base(name, age) { }
        //}

        static void Task4()
        {
            Console.WriteLine("Zadanie 4");

            Console.WriteLine("Dodanie słowa 'sealed' do definicji klasy ChristmasTreeC " +
                "spowodowało zablokowanie dalszego dziedziczenia po niej.");
            Console.WriteLine("Kod błędu kompilacji: CS0509");
        }

        public abstract class Home
        {
            public abstract int Price();
        }

        public class Building : Home
        {
            public override int Price() { return 300000; }
        }

        public class Place : Home
        {
            public override int Price() { return 100000; }
        }

        static void Task5()
        {
            Console.WriteLine("Zadanie 5");

            Building building = new Building();
            Place place = new Place();

            Console.WriteLine("Klasa Home wraz z sygnaturą abstract wymusiła koniecznosć " +
                "zaimplementowania metody Price w klasach pochodnych.");
            Console.WriteLine($"Metoda Price w klasie Building: {building.Price()}");
            Console.WriteLine($"Metoda Price w klasie Place: {place.Price()}");
        }
    }
}

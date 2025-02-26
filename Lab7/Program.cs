using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
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

            Console.ReadKey();
        }

        public class Auto : ICepikData, IStatData, IPoliceData
        {
            public string _carType { get; set; }
            public string _brand { get; set; }
            public int _capacity { get; set; }
            public int _seats { get; set; }
            public string _vin { get; set; }
            public string _plates { get; set; }
            public int _year { get; set; }
            public string _color { get; set; }
            public string _policy { get; set; }

            public string _owner { get; set; }
            public string _address { get; set; }
            public string _pesel { get; set; }
            public string _licenseNumber { get; set; }
            public string _licenseDate { get; set; }
            public int _buyYear { get; set; }
            public int _penaltyPoints { get; set; }

            public Auto(string carType, string brand, int capacity, int seats, string vin, string plates, int year, string color, string policy,
                string owner, string address, string pesel, string licenseNumber, string licenseDate, int buyYear, int penaltyPoints)
            {
                _carType = carType;
                _brand = brand;
                _capacity = capacity;
                _seats = seats;
                _vin = vin;
                _plates = plates;
                _year = year;
                _color = color;
                _policy = policy;

                _owner = owner;
                _address = address;
                _pesel = pesel;
                _licenseNumber = licenseNumber;
                _licenseDate = licenseDate;
                _buyYear = buyYear;
                _penaltyPoints = penaltyPoints;
            }
        }

        interface ICepikData : IStatData
        {
            string _owner { get; }
            string _address { get; }
            string _pesel { get; }
            string _licenseNumber { get; }
            string _licenseDate { get; }
            int _buyYear { get; }
        }

        interface IStatData
        {
            string _carType { get; }
            string _brand { get; }
            int _capacity { get; }
            int _seats { get; }
            string _vin { get; }
            string _plates { get; }
            int _year { get; }
            string _color { get; }
            string _policy { get; }
        }

        interface IPoliceData : ICepikData
        {
            int _penaltyPoints { get; }
        }


        static void Task1()
        {
            Console.WriteLine("Zadanie 1");
            List<ICepikData> cepikDatas = new List<ICepikData>();
            List<IStatData> statDatas = new List<IStatData>();
            List<IPoliceData> policeDatas = new List<IPoliceData>();

            Auto auto1 = new Auto("sedan", "BMW", 55, 5, "VF123456789", "KR12345", 2012, "black", "POL1234567",
                "Maciej Kuś", "ul. uliczna", "12345654321", "123", "12.12.2012", 2013, 7);
            Auto auto2 = new Auto("sedan", "Peugeot", 60, 5, "SD987654321", "WF12345", 2020, "blue", "FGD3579854",
                "Piotr Malusi", "ul. mieszkańców", "143789133", "65249759375", "06.03.1999", 2020, 0);
            Auto auto3 = new Auto("hatchback", "Hyundai", 45, 5, "ZJD372837295", "TB12321", 2023, "red", "BSB538258",
                "Tomasz Byk", "ul. asfalstowa", "8975972542", "RG497879", "03.06.2000", 2023, 14);

            cepikDatas.Add(auto1);
            cepikDatas.Add(auto2);
            cepikDatas.Add(auto3);

            statDatas.Add(auto1);
            statDatas.Add(auto2);
            statDatas.Add(auto3);

            policeDatas.Add(auto1);
            policeDatas.Add(auto2);
            policeDatas.Add(auto3);

            Console.WriteLine("Dane z ICepikData");
            foreach (var data in cepikDatas)
            {
                Console.WriteLine("Car type: " + data._carType + "  Brand: " + data._brand + "  Capacity: " + data._capacity);
                Console.WriteLine("Seats: " + data._seats + "   VIN: " + data._vin + "  Plates: " + data._plates);
                Console.WriteLine("Year: " + data._year + "    Color: " + data._color + "   Policy: " + data._policy);
                Console.WriteLine("Owner: " + data._owner + "   Address: " + data._address + "  Pesel: " + data._pesel);
                Console.WriteLine("License number: " + data._licenseNumber + "   License date: " + data._licenseDate + "  Buy year: " + data._buyYear);
                Console.WriteLine();
            }

            Console.WriteLine("\nDane z IStatData");
            foreach (var data in statDatas)
            {
                Console.WriteLine("Car type: " + data._carType + "  Brand: " + data._brand + "  Capacity: " + data._capacity);
                Console.WriteLine("Seats: " + data._seats + "   VIN: " + data._vin + "  Plates: " + data._plates);
                Console.WriteLine("Year: " + data._year + "    Color: " + data._color + "   Policy: " + data._policy);
                Console.WriteLine();
            }

            Console.WriteLine("\nDane z IPoliceData");
            foreach (var data in policeDatas)
            {
                Console.WriteLine("Car type: " + data._carType + "  Brand: " + data._brand + "  Capacity: " + data._capacity);
                Console.WriteLine("Seats: " + data._seats + "   VIN: " + data._vin + "  Plates: " + data._plates);
                Console.WriteLine("Year: " + data._year + "   Color: " + data._color + "   Policy: " + data._policy);
                Console.WriteLine("Owner: " + data._owner + "   Address: " + data._address + "  Pesel: " + data._pesel);
                Console.WriteLine("License number: " + data._licenseNumber + "   License date: " + data._licenseDate + "  Buy year: " + data._buyYear);
                Console.WriteLine("Penalty points: " + data._penaltyPoints);
                Console.WriteLine();
            }
        }

        public class Point
        {
            public int x;
            public int y;

            public Point(int p1, int p2)
            {
                x = p1;
                y = p2;
            }

            public static Point operator +(Point p1, Point p2)
            {
                Point p3 = new Point(p1.x + p2.x, p1.y + p2.y);
                return p3;
            }
            public static bool operator true(Point p)
            {
                return p.x != 0 || p.y != 0;
            }
            public static bool operator false(Point p)
            {
                return p.x == 0 && p.y == 0;
            }
            public static bool operator ==(Point p1, Point p2)
            {
                return (p1.x == p2.x) && (p1.y == p2.y);
            }
            // należy zdefiniować także operator !=
            public static bool operator !=(Point p1, Point p2)
            {
                return (p1.x != p2.x) || (p1.y != p2.y);
            }
            public static bool operator <(Point p1, Point p2)
            {
                return (p1.x < p2.x) && (p1.y < p2.y);
            }
            public static bool operator <=(Point p1, Point p2)
            {
                return (p1.x <= p2.x) && (p1.y <= p2.y);
            }
            public static bool operator >(Point p1, Point p2)
            {
                return (p1.x > p2.x) && (p1.y > p2.y);
            }
            public static bool operator >=(Point p1, Point p2)
            {
                return (p1.x >= p2.x) && (p1.y >= p2.y);
            }
            public static Point operator ++(Point p)
            {
                p.x += 1;
                p.y += 1;
                return p;
            }
            public static Point operator --(Point p)
            {
                p.x -= 1;
                p.y -= 1;
                return p;
            }
            public static implicit operator Point(int x)
            {
                return new Point(x, 0);
            }
            public static implicit operator int(Point p)
            {
                return p.x + p.y;
            }
            /*public static Point operator +=(Point p1, Point p2)
            {
                p1.x += p2.x;
                p1.y += p2.y;
                return p1;
            }*/
        }

        static void Task2()
        {
            Console.WriteLine("Zadanie 2");
            Point p1 = new Point(3, 2);
            Point p2 = new Point(3, 5);
            Point p3 = new Point(0, 0);
            Console.WriteLine("Punkt 1: {0} {1}", p1.x, p1.y);
            Console.WriteLine("Punkt 2: {0} {1}", p2.x, p2.y);
            Console.WriteLine("Punkt 3: {0} {1}", p3.x, p3.y);

            Point p4 = p1 + p2;
            Console.WriteLine("Przeciążenie p1 + p2: {0} {1}", p4.x, p4.y);
            Console.WriteLine("Przeciążenie true i false:");
            if (p1) { Console.WriteLine("p1 true"); } else { Console.WriteLine("p1 false"); }
            if (p3) { Console.WriteLine("p3 true"); } else { Console.WriteLine("p3 false"); }

            Console.WriteLine("Przeciążenie p2 == p2: {0}", p2 == p2);
            Console.WriteLine("Przeciążenie p1 != p2: {0}", p1 != p2);
            Console.WriteLine("Przeciążenie p2 > p1: {0}", p2 > p1);
            Console.WriteLine("Przeciążenie p2 >= p1: {0}", p2 >= p1);
            Console.WriteLine("Przeciążenie p3 < p2: {0}", p3 < p2);
            Console.WriteLine("Przeciążenie p1 <= p2: {0}", p1 <= p2);

            p3++;
            Console.WriteLine("Przeciążenie p3++ : {0} {1}", p3.x, p3.y);
            p3--;
            Console.WriteLine("Przeciążenie p3-- : {0} {1}", p3.x, p3.y);

            Point p = 5;
            Console.WriteLine("Point p = 5: {0} {1}", p.x, p.y);
            Console.WriteLine("int suma = (int)p2: {0}", (int)p2);
            Console.WriteLine("Nadpisanie += powoduje błąd kompilacji.");
        }


        public delegate void delegateOperations(float x, float y);
        public class Operations
        {
            public static void Add(float x, float y) { Console.WriteLine($"Dodawanie: {x + y}"); }
            public static void Substract(float x, float y) { Console.WriteLine($"Odejmowanie: {x - y}"); }
            public static void Multiply(float x, float y) { Console.WriteLine($"Mnożenie: {x * y}"); }
            public static void Divide(float x, float y) { if (y != 0) { Console.WriteLine($"Dzielenie: {x / y}"); } }
        }

        static void Task3()
        {
            Console.WriteLine("Zadanie 3");
            delegateOperations delegateCount = Operations.Add;
            delegateCount += Operations.Substract;
            delegateCount += Operations.Multiply;
            delegateCount += Operations.Divide;

            Console.WriteLine("delegateCount(5, 7):");
            delegateCount(5, 7);
        }
    }
}

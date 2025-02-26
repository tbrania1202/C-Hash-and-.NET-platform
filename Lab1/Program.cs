using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // zadanie 1
            Console.WriteLine("Zadanie 1");
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // zadanie 2
            //Operacje();

            // zadanie 3
            //Odwrotność();

            // zadanie 4
            //Iloczyn();

            // zadanie 5
            //Prostokąt();

            // zadanie 6
            //Formatowanie();

            // zadanie 7
            //Konwerter();

            // zadanie 8
            Warunek();

            Console.ReadKey();
        }

        static void Operacje()
        {
            Console.WriteLine("\nZadanie 2");
            Console.WriteLine("Dodawanie: 4 + 7 = " + (4 + 7));
            Console.WriteLine("Dzielenie: 16 / 4 = " + (16 / 4));
            Console.WriteLine("-1 + 4 * 6 = " + (-1 + 4 * 6));
            Console.WriteLine("(35+ 5) % 7 = " + ((35 + 5) % 7));
            Console.WriteLine("14 + -4 * 6/11 = " + (14 + -4 * 6.0 / 11));
            Console.WriteLine("2 + 15/6 * 1 - 7% 2 = " + (2 + 15.0 / 6 * 1 - 7 % 2));
        }

        static void Odwrotność()
        {
            Console.WriteLine("\nZadanie 3");
            Console.WriteLine("Podaj pierwszą cyfrę");
            int pierwsza = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj drugą cyfrę");
            int druga = int.Parse(Console.ReadLine());
            Console.WriteLine("Drugi numer: " + druga + " Pierwszy numer: " + pierwsza);
        }

        static void Iloczyn()
        {
            Console.WriteLine("\nZadanie 4");
            Console.WriteLine("Podaj 3 liczby oddzielone znakiem przecinka (bez spacji)");
            string[] liczby = Console.ReadLine().Split(',');
            int[] liczbyInt32 = new int[3];
            int iloczyn = 1;
            for (int i = 0; i < liczby.Length; i++)
            {
                liczbyInt32[i] = Convert.ToInt32(liczby[i]);
                iloczyn *= liczbyInt32[i];
            }
            Console.WriteLine("Iloczyn: {0}x{1}x{2} = {3}", liczby[2], liczby[1], liczby[0], iloczyn);
        }

        static void Prostokąt()
        {
            Console.WriteLine("\nZadanie 5");
            Console.WriteLine("Podaj cyfrę");
            int cyfra = int.Parse(Console.ReadLine());
            for (int i = 0; i < 6; i++)
            {
                if (i == 0 || i == 5)
                {
                    Console.Write(" {0}{0}{0}{0} ", cyfra);
                }
                else
                {
                    Console.Write("{0}    {0}", cyfra);
                }
                Console.WriteLine();
            }
        }

        static void Formatowanie()
        {
            //1
            Console.WriteLine("\nZadanie 6");
            int ii = 75400;
            double id = 7.54;
            string s = string.Format("Wartość int to {0}, a wartość double to {1}", ii.ToString(), id.ToString());
            string s2 = string.Format("Wartość int to " + ii.ToString() + ", a wartość double to " + id.ToString());
            string s3 = string.Format("Wartość int to " + ii + ", a wartość double to " + id);
            Console.WriteLine(s);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            //2
            Console.WriteLine("\nWartość int to ---{0,40}---, a wartość double to {1}", ii, id);
            Console.WriteLine("Wartość int to ---{0,-40}---, a wartość double to {1}", ii, id);
            //3
            int ii2 = 75300;
            double id2 = 7.53;
            Console.WriteLine("\nInt wynosi: {0:c}, double wynosi: {1:c}", ii2, id2);
            Console.WriteLine("Int wynosi: {0:d}", ii2);
            Console.WriteLine("Int wynosi: {0:e}, double wynosi: {1:e}", ii2, id2);
            Console.WriteLine("Int wynosi: {0:f}, double wynosi: {1:f}", ii2, id2);
            Console.WriteLine("Double wynosi: {0:r}", id2);
            Console.WriteLine("Int wynosi: {0:x}", ii2);
            //4
            float flo = 220.022f;
            Console.WriteLine("\nFloat wynosi: {0:0.00000}", flo);
            Console.WriteLine("Float wynosi: {0:[#].(#)(##)}", flo);
            Console.WriteLine("Float wynosi: {0:0.0}", flo);
            Console.WriteLine("Float wynosi: {0:0,0}", flo);
            Console.WriteLine("Float wynosi: {0:,.}", flo);
            Console.WriteLine("Float wynosi: {0:0%}", flo);
            Console.WriteLine("Float wynosi: {0:0e+0}", flo);
            //5
            double d1 = 123.4;
            double d2 = -1234;
            double d3 = 0;
            Console.WriteLine("\nDouble wynosi: {0:#,##0.0;(#,##)Minus;Zero}", d1);
            Console.WriteLine("Double wynosi: {0:#,##0.0;(#,##)Minus;Zero}", d2);
            Console.WriteLine("Double wynosi: {0:#,##0.0;(#,##)Minus;Zero}", d3);
            //6
            DateTime d = System.DateTime.Now;
            Console.WriteLine("\nData: {0:d}", d);
            Console.WriteLine("Data: {0:D}", d);
            Console.WriteLine("Data: {0:t}", d);
            Console.WriteLine("Data: {0:T}", d);
            Console.WriteLine("Data: {0:f}", d);
            Console.WriteLine("Data: {0:F}", d);
            Console.WriteLine("Data: {0:g}", d);
            Console.WriteLine("Data: {0:G}", d);
            Console.WriteLine("Data: {0:M}", d);
            Console.WriteLine("Data: {0:r}", d);
            Console.WriteLine("Data: {0:s}", d);
            Console.WriteLine("Data: {0:u}", d);
            Console.WriteLine("Data: {0:U}", d);
            Console.WriteLine("Data: {0:Y}", d);
        }

        static void Konwerter()
        {
            Console.WriteLine("\nZadanie 7");
            Console.WriteLine("Podaj temperaturę w stopniach Celsjusza");
            int C = int.Parse(Console.ReadLine());
            int K = C + 273;
            float F = (float)(C * 18.0 / 10 + 32);
            Console.WriteLine("Temperatura {0} w stopnach Celsjusza to:", C);
            Console.WriteLine("Kelvin: {0}, Fahrenheit: {1}", K, F);
        }

        static void Warunek()
        {
            Console.WriteLine("\nZadanie 8");
            Console.WriteLine("Podaj dwie cyfry oddzielone spacją");
            string[] dane = Console.ReadLine().Split();
            Console.WriteLine((int.Parse(dane[0]) < 0 && int.Parse(dane[1]) > 0) || (int.Parse(dane[0]) > 0 && int.Parse(dane[1]) < 0));
        }

    }
}

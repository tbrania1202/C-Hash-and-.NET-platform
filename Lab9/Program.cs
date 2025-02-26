using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {
        Task1();
        Console.WriteLine();
        Task2();
        Console.WriteLine();
        Task3();
        Console.ReadKey();
    }

    static void Task1()
    {
        Console.WriteLine("Zadanie 1");

        string[] slowa = new string[]
        {
        // Indeks od początku od końca
        "Już północ", // 0 ^10
        "cień", // 1 ^9
        "ponury", // 2 ^8
        "pół", // 3 ^7
        "świata", // 4 ^6
        "okrywa", // 5 ^5
        "A jeszcze", // 6 ^4
        "serce", // 7 ^3
        "zmysłom", // 8 ^2
        "spoczynku nie daje" // 9 ^1
                        // 10(słowa.Lenght) ^0
        };

        Console.WriteLine("#1");
        Console.WriteLine($"{slowa[^1]}");

        Console.WriteLine("#2");
        string[] sonet1 = slowa[2..6];
        foreach (var slowo in sonet1)
            Console.Write($"< {slowo} >");
        Console.WriteLine();

        Console.WriteLine("#3");
        string[] sonet2 = slowa[^3..^0];
        foreach (var slowo in sonet2)
            Console.Write($"{slowo}");
        Console.WriteLine();

        Console.WriteLine("#4");
        string[] sonet3 = slowa[..];
        string[] sonet4 = slowa[..5];
        string[] sonet5 = slowa[7..];
        foreach (var slowo in sonet3)
            Console.Write($"{slowo}");
        Console.WriteLine();
        foreach (var slowo in sonet4)
            Console.Write($"{slowo}");
        Console.WriteLine();
        foreach (var slowo in sonet5)
            Console.Write($"{slowo}");
        Console.WriteLine();

        Console.WriteLine("#5");
        Index stri = ^5;
        Console.WriteLine(slowa[stri]);

        Console.WriteLine("#6");
        Range fraza = 2..7;
        string[] tekst = slowa[fraza];
        foreach (var slowo in tekst)
            Console.Write($" {slowo} ");
        Console.WriteLine();
    } 
    

    public delegate void DigitEventHandler();
    public static event DigitEventHandler OnDigit;
    public static void HandleDigitEvent()
    {
        Console.WriteLine("\nNaciśnięto cyfrę!");
    }

    public delegate void CharacterEventHandler();
    public static event CharacterEventHandler OnCharacter;
    public static void HandleCharacterEvent()
    {
        Console.WriteLine("\nNaciśnięto literę!");
    }

    static void Task2()
    {
        Console.WriteLine("Zadanie 2");

        OnDigit += HandleDigitEvent;
        OnCharacter += HandleCharacterEvent;

        while (true)
        {
            Console.WriteLine("Podaj znak z klawiatury");
            char x = Console.ReadKey().KeyChar;
            if (char.IsDigit(x))
            {
                OnDigit?.Invoke();
            }
            else if (char.IsLetter(x))
            {
                OnCharacter?.Invoke();
            }
            else
            {
                break;
            }
        }
    }

    public class DisposeObject: IDisposable
    {
        protected bool disposed = false;
        private IntPtr handle;
        private Component components = new Component();

        public DisposeObject(int copylen)
        {
            handle = Marshal.AllocHGlobal(copylen + 1);
            Console.WriteLine("Po utworzeniu handle:");
            Console.WriteLine(handle);
        }

        ~DisposeObject()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    components?.Dispose();
                }
                //CloseHandle(handle);
                Marshal.FreeHGlobal(handle);
                handle = IntPtr.Zero;
                Console.WriteLine("Po wykonaniu Dispose handle:");
                Console.WriteLine(handle);
            }
            disposed = true;
        }
    }

    static void Task3()
    {
        Console.WriteLine("Zadanie 3");

        DisposeObject obj1 = new DisposeObject(3);
        obj1.Dispose();
    }
}



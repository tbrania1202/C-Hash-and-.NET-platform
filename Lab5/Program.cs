using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using static Lab5.Program;
using System.Data;
using System.Runtime.Serialization.Formatters;
using System.Security.Permissions;

namespace Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Zadanie 1
            //Loop();

            //Zadanie 2
            //BoxingandUnboxing();

            //Zadanie 3
            //Nullable1();

            //Zadanie 4
            //Nullable2();

            //Zadanie 5
            //P_Invoke();

            //Zadanie 6
            //Stack1();

            //Zadanie 7
            //Matrix1();

            //Zadanie 8
            //Matrix2();

            //Zadanie 9
            Book1();

            Console.ReadKey();
        }

        static void Loop()
        {
            Console.WriteLine("Zadanie 1");
            Console.WriteLine("Podaj cyfrę:");
            int x = int.Parse(Console.ReadLine());

            for (int i = 1; i <= x; i++)
            {
                Console.WriteLine(string.Join("", Enumerable.Range(1, i)));
            }
            Console.WriteLine();

            int n = 1;
            while (n <= x)
            {
                Console.WriteLine(string.Join("", Enumerable.Range(1, n)));
                n++;
            }
            Console.WriteLine();

            n = 1;
            do
            {
                Console.WriteLine(string.Join("", Enumerable.Range(1, n)));
                n++;
            } while (n <= x);
            Console.WriteLine();

            for (int i = 1; i <= x; i++)
            {
                Console.WriteLine(new string((char)('0' + i), i));
            }
            Console.WriteLine();

            n = 1;
            while(n <= x)
            {
                Console.WriteLine(new string((char)('0' + n), n));
                n++;
            }
            Console.WriteLine();

            n = 1;
            do
            {
                Console.WriteLine(new string((char)('0' + n), n));
                n++;
            } while (n <= x);
            Console.WriteLine();
        }

        static void BoxingandUnboxing()
        {
            Console.WriteLine("Zadanie 2");
            Int32 i = 23;
            object o = i;
            i = 123;
            Console.WriteLine(i + ", " + (Int32)o);
            Console.WriteLine("Wartość zmiennej i jest przypisana do zmiennej o.\n" +
                "Wartość o staje się referencją do obiektu przechowującego wartość 23.\n" +
                "i = 123, ponieważ jest to zmienna, której nadano ostatecznie taką wartość.\n");

            long j = (long)(Int32)o;
            Console.WriteLine(i + ", " + j);
            Console.WriteLine("Rzutowanie long j = (long)o nie jest poprawne (otrzymamy błąd),\n" +
                "ponieważ o jest typu ogólnego object, a nie typem Int32.\n" +
                "Poprawna konwersja to: long j = (long)(Int32)o");
        }

        static void Nullable1()
        {
            Console.WriteLine("Zadanie 3");
            int? x = null;
            Console.WriteLine("Zmienna nullable: {0}", x);

            int result = x.GetValueOrDefault();
            Console.WriteLine("Wartość zmiennej z GetValueOrDefault(): " + result);
            if (!x.HasValue)
            {
                Console.WriteLine("HasValue: Zmienna jest null");
            }
            else
            {
                Console.WriteLine("Wartość zmiennej: " + x.Value);
            }

            x = 5;
            Console.WriteLine("Nullable po przypisaniu wartości: {0}", x);
        }

        static void Nullable2()
        {
            Console.WriteLine("Zadanie 4");
            int? i = null;
            int j = 10;
            Console.WriteLine("i = null, j = 10");
            Console.WriteLine($"i < j: {i < j}");
            Console.WriteLine($"i == j: {i == j}");
            Console.WriteLine($"i > j: {i > j}");

            i = 10;
            Console.WriteLine("\ni = 10(nullable), j = 10");
            Console.WriteLine($"i < j: {i < j}");
            Console.WriteLine($"i == j: {i == j}");
            Console.WriteLine($"i > j: {i > j}");
        }


        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int puts(string str);

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _flushall();

        static void P_Invoke()
        {
            Console.WriteLine("Zadanie 5");
            string str = "Informacja";
            int result = puts(str);
            if (result >= 0)
            {
                _flushall();
            }

        }

        class Stack<T>
        {
            private List<T> stack = new List<T>();

            public void AddItem(T item)
            {
                stack.Add(item);
            }

            public T DeleteItem()
            {
                T item = stack[0];
                stack.RemoveAt(0);
                return item;
            }
            public int ShowTheNumberOfItems()
            {
                return stack.Count;
            }

            public T ShowMinItem()
            {
                return stack.Min();
            }

            public T ShowMaxItem()
            {
                return stack.Max();
            }

            public int FindAnItem(T item)
            {
                for (int i = 0; i < stack.Count; i++) 
                {
                    if (stack[i].Equals(item))
                    {
                        return i;
                    }
                }
                return -1;
            }

            public void PrintAllItems()
            {
                foreach (T item in stack)
                {
                    Console.Write(item + " ");
                }
            }

            public void ClearAll()
            {
                stack.Clear();
            }

            public T GetByIndex(int index)
            {
                return stack[index];
            }

        }

        static void Stack1()
        {
            Console.WriteLine("Zadanie 6");

            Stack<int> stack1 = new Stack<int>();
            Stack<int> stack2 = new Stack<int>();
            Stack<int> stack3 = new Stack<int>();

            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                stack1.AddItem(random.Next(1, 100));
                stack2.AddItem(random.Next(1, 100));
            }

            Console.WriteLine("Ilość elementów w stosie 1: {0}", stack1.ShowTheNumberOfItems());
            Console.WriteLine("Ilość elementów w stosie 2: {0}", stack2.ShowTheNumberOfItems());
            Console.WriteLine("\nStos 1:");
            stack1.PrintAllItems();
            Console.WriteLine("\n\nStos 2:");
            stack2.PrintAllItems();

            for (int i = 0; i < stack1.ShowTheNumberOfItems(); i++)
            {
                int s1 = stack1.GetByIndex(i);
                int s2 = stack2.GetByIndex(i);
                if (s1 % 2 == 0)
                {
                    if (stack3.FindAnItem(s1) == -1)
                    {
                        stack3.AddItem(s1);
                    }
                }
                if (s2 % 2 == 0) 
                { 
                    if (stack3.FindAnItem(s2) == -1)
                    {
                        stack3.AddItem(s2);
                    }
                }
            }
            Console.WriteLine("\nIlość elementów w stosie 1: {0}", stack1.ShowTheNumberOfItems());
            Console.WriteLine("Ilość elementów w stosie 2: {0}", stack2.ShowTheNumberOfItems());
            Console.WriteLine("Ilość elementów w stosie 3: {0}", stack3.ShowTheNumberOfItems());
            Console.WriteLine("\nStos 3:");
            stack3.PrintAllItems();
        }

        public class Matrix
        {
            private int[] _matrix;
            private int rows;
            private int columns;
            
            public Matrix(int rows, int columns, params int[] values)
            {
                this.rows = rows;
                this.columns = columns;
                int elements = rows * columns;
                _matrix = new int[elements];
                for (int i = 0; i < elements; i++)
                {
                    if (i < values.Length)
                    {
                        _matrix[i] = values[i];
                    }
                    else
                    {
                        _matrix[i] = 0;
                    }
                }
            }

            public void ShowMatrix()
            {
                for (int i = 0; i < this.rows; i++)
                {
                    for (int j = 0; j < this.columns; j++)
                    {
                        Console.Write(_matrix[this.columns * i + j] + " ");
                    }
                    Console.WriteLine();
                }
            }

            public void AddElem(int row, int column, int value)
            {
                if (row >= 0 && row <= this.rows && column >= 0 && column <= this.columns)
                {
                    _matrix[row * this.columns + column] = value;
                }
                else
                {
                    Console.WriteLine("Błąd wpisania elementu");
                }
            }

            public int GetRowCount()
            {
                return this.rows;
            }

            public int GetColumnCount()
            {
                return this.columns;
            }

            public Matrix GetMatrix(int row, int column)
            {
                Matrix copy = new Matrix(row, column);
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        if (i < this.rows && j < this.columns)
                        {
                            copy._matrix[column * i + j] = _matrix[this.columns * i + j];

                        }
                        else
                        {
                            copy._matrix[column * i + j] = 0;
                        }
                        
                    }
                }
                return copy;
            }

            public Matrix AddMatrix(Matrix matrix2) 
            {
                int row = Math.Max(this.GetRowCount(), matrix2.GetRowCount());
                int column = Math.Max(this.GetColumnCount(), matrix2.GetColumnCount());
                Matrix new_matrix = new Matrix(row, column);
                Matrix this_copy = this.GetMatrix(row, column);
                Matrix matrix2_copy = matrix2.GetMatrix(row, column);
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        new_matrix._matrix[column * i + j] = this_copy._matrix[column * i + j] + matrix2_copy._matrix[column * i + j];
                    }
                }
                return new_matrix;
            }
        }

        static void Matrix1()
        {
            Console.WriteLine("Zadanie 7");
            Matrix matrix1 = new Matrix(3,3, 1,2,3,4,5,6,7);
            Console.WriteLine("Macierz 1:");
            matrix1.ShowMatrix();

            Matrix matrix2 = new Matrix(4,2, 2,3,6,1,9,1,2,2);
            Console.WriteLine("Macierz 2:");
            matrix2.ShowMatrix();

            Matrix matrix3 = matrix1.AddMatrix(matrix2);
            Console.WriteLine("Macierz 1 + Macierz 2 = Macierz 3:");
            matrix3.ShowMatrix();

            Matrix matrix4 = new Matrix(2,3, 1, 2, 3, 4, 5, 6, 7, 8, 9);
            Console.WriteLine("Macierz 4:");
            matrix4.ShowMatrix();

            Matrix matrix5 = new Matrix(3,2, 2,4,5,1,6);
            Console.WriteLine("Macierz 5:");
            matrix5.ShowMatrix();

            Matrix matrix6 = matrix4.AddMatrix(matrix5);
            Console.WriteLine("Macierz 4 + Macierz 5 = Macierz 6:");
            matrix6.ShowMatrix();
        }

        public class Matrix_v2
        {
            protected int[][] _matrix;
            protected int rows;
            protected int columns;

            public Matrix_v2(int rows, int columns, params int[] values)
            {
                this.rows = rows;
                this.columns = columns;
                _matrix = new int[rows][];
                for (int i = 0; i < rows; i++)
                {
                    _matrix[i] = new int[columns];
                    for (int j = 0; j < columns; j++)
                    {
                        if (i * columns + j < values.Length)
                        {
                            _matrix[i][j] = values[i * columns + j];
                        }
                        else
                        {
                            _matrix[i][j] = 0;
                        }
                    }
                }
            }

            public void ShowMatrix()
            {
                for (int i = 0; i < this.rows; i++)
                {
                    for (int j = 0; j < this.columns; j++)
                    {
                        Console.Write(_matrix[i][j] + " ");
                    }
                    Console.WriteLine();
                }
            }

            public void AddElem(int row, int column, int value)
            {
                if (row >= 0 && row <= this.rows && column >= 0 && column <= this.columns)
                {
                    _matrix[row][column] = value;
                }
                else
                {
                    Console.WriteLine("Błąd wpisania elementu");
                }
            }

            public int GetRowCount()
            {
                return this.rows;
            }

            public int GetColumnCount()
            {
                return this.columns;
            }

            public Matrix_v2 GetMatrix(int row, int column)
            {
                Matrix_v2 copy = new Matrix_v2(row, column);
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        if (i < this.rows && j < this.columns)
                        {
                            copy._matrix[i][j] = _matrix[i][j];
                        }
                        else
                        {
                            copy._matrix[i][j] = 0;
                        }

                    }
                }
                return copy;
            }

            public Matrix_v2 AddMatrix(Matrix_v2 matrix2)
            {
                int row = Math.Max(this.GetRowCount(), matrix2.GetRowCount());
                int column = Math.Max(this.GetColumnCount(), matrix2.GetColumnCount());
                Matrix_v2 new_matrix = new Matrix_v2(row, column);
                Matrix_v2 this_copy = this.GetMatrix(row, column);
                Matrix_v2 matrix2_copy = matrix2.GetMatrix(row, column);
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        new_matrix._matrix[i][j] = this_copy._matrix[i][j] + matrix2_copy._matrix[i][j];
                    }
                }
                return new_matrix;
            }
        }

        static void Matrix2()
        {
            Console.WriteLine("Zadanie 8");
            Matrix_v2 matrix1 = new Matrix_v2(2, 3, 1, 2, 3, 4, 5, 6, 7, 8);
            Console.WriteLine("Macierz 1:");
            matrix1.ShowMatrix();

            Matrix_v2 matrix2 = new Matrix_v2(4, 2, 2, 3, 6, 1, 9, 1, 2);
            Console.WriteLine("Macierz 2:");
            matrix2.ShowMatrix();

            Matrix_v2 matrix3 = matrix1.AddMatrix(matrix2);
            Console.WriteLine("Macierz 1 + Macierz 2 = Macierz 3:");
            matrix3.ShowMatrix();
        }

        public class Book
        {
            private string _title;
            private string _author;
            private double _price;
            private readonly string _isbn;
            private DateTime date;

            public Book(string title, string author, double price, string isbn)
            {
                _title = title;
                _author = author;
                _price = price;
                _isbn = isbn;
                date = DateTime.Now;
            }

            public string Title => _title;
            public string Author => _author;
            public double Price => _price;
            public string Isbn => _isbn;
            public DateTime Date => date;

            public override string ToString()
            {
                return $"Title: {_title}, Author: {_author}, Price: {_price}, ISBN: {_isbn}, Date: {date}";
            }
        }

        public class BookLibrary
        {
            private static BookLibrary instance;
            private List<Book> _books = new List<Book>();

            private BookLibrary()
            {

            }

            public static BookLibrary Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new BookLibrary();
                    }
                    return instance;
                }
            }
            public void Add(Book book)
            {
                if (!_books.Any(b => b.Isbn == book.Isbn))
                {
                    _books.Add(book);
                }
                else
                {
                    Console.WriteLine("Istenieje już książka z takim samym kodem ISBN");
                }
            }

            public void Remove(string isbn)
            {
                Book checkBook = SearchByISBN(isbn);
                if (checkBook != null)
                {
                    _books.Remove(checkBook);
                }
                else 
                {
                    Console.WriteLine("Nie znaleziono książki");
                }
            }

            public Book SearchByISBN(string isbn)
            {
                return _books.FirstOrDefault(b => b.Isbn == isbn);
            }

            public List<Book> SearchByAuthor(string author)
            {
                return _books.Where(b => b.Author == author).ToList();
            }

            public List<Book> SearchByTitle(string title)
            {
                return _books.Where(b => b.Title == title).ToList();
            }

            public List<Book> SearchByPrice(double price)
            {
                return _books.Where(b => b.Price == price).ToList();
            }

            public void ListBooks()
            {
                foreach (Book book in _books)
                {
                    Console.WriteLine(book.ToString());
                }
            }

            public bool IfContains(string isbn)
            {
                return _books.Any(b => b.Isbn == isbn);
            }
        }

        static void Book1()
        {
            Console.WriteLine("Zadanie 9");
            // próba utworzenia dwóch instancji
            BookLibrary bookLibrary = BookLibrary.Instance;
            BookLibrary bookLibrary1 = BookLibrary.Instance;
            // błąd kompilacji
            //BookLibrary bookLibrary2 = new BookLibrary();

            Book book1 = new Book("Book1", "Author1", 30, "ISBN11");
            Book book2 = new Book("Book2", "Author2", 25, "ISBN22");
            Book book3 = new Book("Book3", "Author1", 30, "ISBN33");
            Book book4 = new Book("Book1", "Author1", 35, "ISBN44");
            bookLibrary.Add(book1);
            bookLibrary.Add(book2);
            bookLibrary.Add(book3);
            bookLibrary1.Add(book4);

            Console.WriteLine("Biblioteka po dodaniu książek:");
            bookLibrary1.ListBooks();

            Console.WriteLine("\nLista książek autora Author1:");
            List<Book> booksByAuthor = bookLibrary.SearchByAuthor("Author1");
            foreach (Book book in booksByAuthor)
            {
                Console.WriteLine(book.ToString());
            }

            Console.WriteLine("\nLista książek o tytule Book1 po usunięciu tej o nr ISBN44:");
            bookLibrary.Remove("ISBN44");
            List<Book> booksByTitle = bookLibrary.SearchByTitle("Book1");
            foreach (Book book in booksByTitle)
            {
                Console.WriteLine(book.ToString());
            }

            Console.WriteLine("\nLista książek całościowa:");
            bookLibrary.ListBooks();

            Console.WriteLine("\nCzy w bibliotece jest książka o nr ISBN55: {0}", bookLibrary.IfContains("ISBN55"));

            Console.WriteLine("\nLista książek z ceną wynoszącą 30:");
            List<Book> booksByPrice = bookLibrary.SearchByPrice(30);
            foreach (Book book in booksByPrice)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }
}

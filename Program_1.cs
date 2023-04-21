/* C#, lesson_39  08.04.2023																																					
																																					
Task № 1:																																					
Створіть клас «Книга», який має зберігати таку інформацію:																																					
? назва книги;																																					
? П.І.Б. автора;																																					
? жанр;																																					
? рік.																																					
Реалізуйте у класі методи та властивості, необхідні для функціонування класу.																																					
Додайте до класу фіналізатор. Напишіть код для тестування функціональності класу.																																					
Напишіть код для фіналізатора. 																																					
																																					
Task № 3:																																					
Додайте до першого завдання реалізацію інтерфейсу IDisposable. Напишіть код для тестування нових можливостей.*/
//--------------------------------------------------------------------------------------------------------																																					
using System;
using System.Globalization;

namespace Lesson_39
{

    //--------------------------------------------------------------------------------------------------------																																					
    class Book : IDisposable                      // оголошення класу книга, реалізація інтерфейсу																																					
    {
        private string name;
        private string author;
        private string genre;
        private int year;
        private int page;
        private int ID;
        public static int count;

        public string NAME                      // властивість для name																																					
        {
            set { this.name = value; }
            get { return this.name; }
        }

        public string AUTHOR                    // властивість для author																																					
        {
            set { this.author = value; }
            get { return this.author; }
        }

        public string GENRE                    // властивість для genre																																					
        {
            set { this.genre = value; }
            get { return this.genre; }
        }

        public int YEAR                    // властивість для year																																					
        {
            set { this.year = value; }
            get { return this.year; }
        }

        public int PAGE                    // властивість для page																																					
        {
            set { this.page = value; }
            get { return this.page; }
        }

        public int GetID()                    // метод - геттер для ID																																					
        {
            return this.ID;
        }

        public Book()                    // конструктор за замовчуванням																																					
        {
            count++;
            ID = count;
        }

        static Book()                   // статичний конструктор 																																					
        {
            count = 0;
        }

        public Book(string name, string author, string genre, int year, int page)       // конструктор з параметрами																																					
        {
            NAME = name;
            AUTHOR = author;
            GENRE = genre;
            YEAR = year;
            PAGE = page;
            count++;
            ID = count;
        }

        public override string ToString()       // метод для друкування книги																																					
        {
            return ("\n================================================================================" +
                    $"\nInfo about book ID { ID } \n\nName: { NAME }" +
                    $"\nAuthor: { AUTHOR } \nGenre: { GENRE }" +
                    $"\nyear: { YEAR } \ncount pages: { PAGE }");
        }

        public void Dispose()                   // метод - реалізація з інтерфейсу методу Dispose																																					
        {
            Console.WriteLine($"Book ID {this.ID} was deleted from the library by the disposer");
            GC.SuppressFinalize(this);          // цей рядок коду - щоб після Dispose для цього об'єкту класу не викликався фіналізатор																																					
        }

        ~Book()                             // фіналізатор																																					
        {
            Console.WriteLine($"Book ID {this.ID} was deleted from the library by the finalizer");
        }
    }

    /*********************************************************************************************************************/
    internal class Program_1
    {
        static Random number = new Random();
        static string BookInitilazer(int size)          // статичний метод - генерація випадкового набору символів для назви, автора і жанру книги																																					
        {
            string str = "";
            for (int i = 0; i < size; i++)
            {
                if (i == 0)
                {
                    str = str + Convert.ToString(Convert.ToChar(number.Next(97, 123))).ToUpper();
                }
                else
                {
                    str = str + Convert.ToString(Convert.ToChar(number.Next(97, 123)));
                }
            }
            return str;
        }

        static int NumberInitilazer(int index)          // статичний метод - генерація випадкових чисел для року видання книги і кількості сторінок																																					
        {
            if (index == 1)
            {
                return number.Next(1700, 2024);     // генерація випадкового числа - рік видання книги																																					
            }
            else
            {
                return number.Next(100, 501);     // генерація випадкового числа - кількість сторінок книги																																					
            }
        }
        //--------------------------------------------------------------------------------------------------------																																					
        static void Main(string[] args)
        {
            Console.WriteLine("Program \"C# lesson_39 \"Task 1\"\n");

            long memory = GC.GetTotalMemory(false); int index, size, number;    // об'єм зайнятої пам'яті до створення об'єктів класу Book																																					

            do
            {
                do													// запит розміру масиву об'єктів класу - кількість книг																								
                {
                    Console.Write("\nEnter the count books in your library ( > 0 ): ");
                    size = Convert.ToInt32(Console.ReadLine());
                    if (size < 1)
                        Console.WriteLine("Incorrect! Try again\n");
                } while (size < 1);

                Book[] books = new Book[size];                  // створення масиву книг																																					

                for (index = 0; index < size; index++)          // ініціалізація масиву книг випадковими значеннями																																					
                {
                    books[index] = new Book();
                    books[index].NAME = BookInitilazer(7);
                    books[index].AUTHOR = BookInitilazer(6);
                    books[index].GENRE = BookInitilazer(5);
                    books[index].YEAR = NumberInitilazer(1);
                    books[index].PAGE = NumberInitilazer(2);
                }

                Console.Write("\n\nDo you want to print your library? ('1' for 'yes'): ");  // друк масиву книг в консолі																																					
                index = Convert.ToInt32(Console.ReadLine());
                if (index == 1)
                {
                    for (index = 0; index < books.Length; index++)
                    {
                        Console.WriteLine(books[index].ToString());
                    }
                }

                Console.Write($"\n\nYour disc has divided into {GC.MaxGeneration + 1} clusters ");      // кількість поколінь, в яких будуть розміщені об'єкти класу																																					

                Console.Write($"\n\nUsed disc space before recording the library: {memory} bytes on disc");     // друк об'єму зайнятої пам'яті до створення об'єктів класу Book																																					
                Console.Write($"\n\nYour library takes up {GC.GetTotalMemory(false)} bytes on disc (total)");  // друк об'єму зайнятої пам'яті після створення об'єктів класу Book																																					
                Console.Write($"\n\nYour library takes up {GC.GetTotalMemory(false) - memory} bytes on disc (only books)");  // друк об'єму зайнятої пам'яті після створення об'єктів класу Book																																					

                Console.WriteLine(); Console.WriteLine();
                for (index = 0; index < size; index++)          // друк номеру покоління, в якому розміщений об'єкт книги																																					
                {
                    Console.WriteLine($"Book ID { books[index].GetID() } is placed in {GC.GetGeneration(books[index]) + 1} cluster on the disc.");
                }


                GC.Collect();                               // перший запуск GC, об'єкти перейдуть в наступне покоління																																					
                Console.WriteLine(); Console.WriteLine("The book place on the disc after optimization: ");
                for (index = 0; index < size; index++)          // друк номеру покоління, в якому розміщений об'єкт книги після GC																																					
                {
                    Console.WriteLine($"Book ID { books[index].GetID() } is placed in {GC.GetGeneration(books[index]) + 1} cluster on the disc.");
                }

                Console.Write("\n\nDo you want to delete any books from the library? ('1' for 'yes'): ");   // експерименти - запит чи видаляти книги з масиву?																																					
                index = Convert.ToInt32(Console.ReadLine());

                if (index == 1)
                {
                    do
                    {
                        Console.Write($"\nHow many books do you want to delete ( > 0...<= {size} ): ");     // скільки книг видаляти?																																					
                        index = Convert.ToInt32(Console.ReadLine());
                        if (index < 1 || index > size)
                            Console.WriteLine("Incorrect! Try again\n");
                    } while (index < 1 || index > size);

                    int[] arr = new int[index];                             // формування масиву номерів книг для видалення																																					

                    for (int i = 0; i < index; i++)
                    {
                        do
                        {
                            Console.Write($"\nEnter the number book to delete: ( > 0...<= {size} ): "); // введення номерів книг для видалення																																					
                            number = Convert.ToInt32(Console.ReadLine());
                            if (number < 1 || number > size)
                                Console.WriteLine("Incorrect! Try again\n");
                        } while (number < 1 || number > size);

                        arr[i] = number;
                    }
                    Array.Sort(arr);  							// сортування номерів книг по за зменшенням номеру (спочатку видаляються книги з кінця, щоб не порушити масив)																														
                    Array.Reverse(arr);


                    for (int i = 0; i < arr.Length; i++)
                    {
                        books[arr[i] - 1].Dispose();            // видалення книги через Dispose (чому в мене Dispose працює без обгортки using?) 																																					
                                                                // (як зробити обгортку using при створенні масиву об'єктів в рядку 159 програми?)																																					

                        for (int j = arr[i] - 1; j < books.Length - 1; j++)     // переформування масиву без видаленої книги																																					
                        {
                            books[j] = books[j + 1];
                        }
                        Array.Resize(ref books, books.Length - 1);
                    }
                }

                Console.Write("\n\nYour library on the disc after deleting: ");     // друк масиву книг після видалення																																					
                for (index = 0; index < books.Length; index++)
                {
                    Console.WriteLine(books[index].ToString());
                }
                // об'єм пам'яті, які займають книги, після видалення 																																					
                Console.Write($"\n\nYour library takes up {GC.GetTotalMemory(false) - memory} bytes on disc after deleting (only books)");


                //--------------------------------------------------------------------------------------------------------																																					

                // продовжити ?																																					
                Console.Write("\n\nDo you want to create another library? ('1' for 'yes'): ");
                index = Convert.ToInt32(Console.ReadLine());
                if (index == 1)
                {
                    for (int i = 0; i < books.Length; i++)
                    {
                        books[i] = null;                        // обнулення посилання на кожну книгу перед знищенням масиву																																					
                    }
                    GC.Collect();                       // виклик GC																																					
                                                        // виклик методу, який зупняє програму, поки не відпрацють фіналізатори для всіх об'єктів																																					
                    GC.WaitForPendingFinalizers();      // (але в мене фіналізатори чомусь не викликаються тут, а викликаються пізніше)																																					
                }
            } while (index == 1);


            Console.WriteLine("\n\nThe library is closed ...\n\n");
        }
    }
}

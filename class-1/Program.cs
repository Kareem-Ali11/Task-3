using System.ComponentModel;

namespace class_1
{
    class Book
    {

        public Book(string title, string iSBN, string author, bool availability = true)
        {
            Title = title;
            ISBN = iSBN;
            Availability = availability;
            Author = author;
        }

        public string Title { get; private set; }
        public string Author { get; set; }
        public bool Availability { get;  set; }
        public string ISBN { get; private set; }
    }
    class Library
    {
        List<Book> books = new List<Book>();

        
        public void AddBook(string title, string isbn, string author)
        {
            books.Add(new Book(title, isbn, author, true));
        }

        public string SearchBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title == title)
                {
                    string show = $"Title: {books[i].Title}, Author: {books[i].Author}, ISBN: {books[i].ISBN}, Available: {(books[i].Availability ? "Yes" : "No")}";
                    return show;
                }
            }
            return "Book not found";
        }


        public string BorrowBook(string isbn)
        {
            Book book = null;

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].ISBN == isbn)
                {
                    book = books[i];
                    break;
                }
            }

            if (book == null)
                return "Book not found";
            if (!book.Availability) 
                return "Book already borrowed";

            book.Availability = false;
            return "Book borrowed successfully";
        }

        public string ReturnBook(string isbn)
        {
            Book book = null;

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].ISBN == isbn)
                {
                    book = books[i];
                    break;
                }
            }

            if (book == null)
                return "Book not found";      
            if (book.Availability) 
                return "Book already here"; 

            book.Availability = true; 
            return "Book returned successfully";
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our Library Management System");

            Library KareemLibrary = new Library();
            KareemLibrary.AddBook("العادات السبع للناس الأكثر فعالية ", "978-977-09-1234-1", "ستيفن كوفي");
            KareemLibrary.AddBook("رجال من المريخ ونساء من الزهرة ", "978-977-09-5678-2", "جون غرايي");
            KareemLibrary.AddBook("الأجنحة المتكسرة", "978-9953-00-1122-3", "جبران خليل جبران");
            KareemLibrary.AddBook("أولاد حارتنا", "978-977-09-5566-5", "نجيب محفوظ");


            Console.WriteLine( KareemLibrary.SearchBook("الأجنحة المتكسرة")); هناهيدينا مش موجود عشانم انا عامل space بعد اسم الكتاب في الاددد

         
            Console.WriteLine(KareemLibrary.BorrowBook("978-9953-00-1122-3"));// هنا استعرت كتاب
            Console.WriteLine(KareemLibrary.SearchBook("الأجنحة المتكسرة")); //وهنا بحثت عن نفس الكتاب
            Console.WriteLine( KareemLibrary.ReturnBook("978-9953-00-1122-3"));//هنا رجعت بقي كتاب


            Console.WriteLine(KareemLibrary.SearchBook("أولاد حارتنا")); //بحثت عن كتاب تاني خالص


        }
    }
}

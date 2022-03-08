using BookSuggester.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials; //FileSystem

namespace BookSuggester.Services
{
    public static class BookService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()  //adatbázis készítése
        {
            if (db != null) //ha már van ne csinálja meg még egyszer
            {
                return;
            }
            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db"); //útvonal mappával, ahol létrehozza

            db = new SQLiteAsyncConnection(databasePath); //connection

            await db.CreateTableAsync<Book>(); //tábla létrehozása

            //await db.DeleteAllAsync<Book>();  //összes törlése, próba
        }
        /*public static async Task AddBook(string isbn, string author, string title, string publisher, string subject, int pubdate, bool isreaded, bool isinprogress, bool issaved) //isbn, szerző, cím, műfaj, kiadó, kiadás éve, kép??                                                            
        {
            await Init();
            var image = "D:/Julia/!suli/!PE-MIK/diplomadolgozat/BookSuggester/BookSuggester/BookSuggester.Android/Resources/drawable/AC-GyAOE.jpg";
            var book = new Book
            {
                ISBN = isbn,
                Author = author,
                Title = title,
                Publisher = publisher,
                Subject = subject,
                PubDate = pubdate,
                IsReaded = isreaded,
                IsInProgress = isinprogress,
                IsSaved = issaved,
                Image = image
            };

            var id = await db.InsertAsync(book);
        }*/
        public static async Task AddBook(string isbn, string author, string title)
        {
            await Init();
            var image = "AC-GyAOE.jpg";
            var book = new Book
            {
                ISBN = isbn,
                Author = author,
                Title = title,
                Image = image
            };

            var id = await db.InsertAsync(book);
        }
        public static async Task RemoveBook(int id)
        {
            await Init();

            await db.DeleteAsync<Book>(id);
        }
        public static async Task<IEnumerable<Book>> GetBook()
        {
            await Init();

            var book = await db.Table<Book>().ToListAsync();

            foreach (var s in book)  //console-ra kiíratom
            {
                Console.WriteLine("ISBN: " + s.ISBN);
                Console.WriteLine("Szerző:: " + s.Author);
                Console.WriteLine("Cím: " + s.Title);
            }

            return book;
        }
    }
}

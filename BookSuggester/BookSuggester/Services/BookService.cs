using BookSuggester.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace BookSuggester.Services
{
    static class BookService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()  //adatbázis készítése
        {
            if (db != null) //ha már van ne csinálja meg még egyszer
                return;
            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db"); //útvonal mappával, ahol létrehozza

            db = new SQLiteAsyncConnection(databasePath); //connection

            await db.CreateTableAsync<Book>(); //tábla létrehozása
        }
        public static async Task AddBook(string isbn, string author, string title, string publisher, string subject, int pubdate) //isbn, szerző, cím, műfaj, kiadó, kiadás éve, kép??                                                            
        {
            await Init();
            var book = new Book
            {
                ISBN = isbn,
                Author = author,
                Title = title,
                Publisher = publisher,
                Subject = subject,
                PubDate = pubdate
            };

            var id = await db.InsertAsync(book);
        }
        public static async Task AddBook(string isbn, string author, string title)                                                            
        {
            await Init();
            var book = new Book
            {
                ISBN = isbn,
                Author = author,
                Title = title
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
            return book;
        }
    }
}

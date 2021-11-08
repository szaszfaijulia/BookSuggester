using BookSuggester.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSuggester.Services
{
    public class MockDataStore : IDataStore<Book>
    {
        readonly List<Book> books;

        public MockDataStore()
        {
            books = new List<Book>()
            {
                new Book { ISBN = Guid.NewGuid().ToString(), AuthorID = 1, Title="This is an item description." },
                new Book { ISBN = Guid.NewGuid().ToString(), AuthorID = 1, Title="This is an item description." },
                new Book { ISBN = Guid.NewGuid().ToString(), AuthorID = 1, Title="This is an item description." },
                new Book { ISBN = Guid.NewGuid().ToString(), AuthorID = 1, Title="This is an item description." },
                new Book { ISBN = Guid.NewGuid().ToString(), AuthorID = 1, Title="This is an item description." },
                new Book { ISBN = Guid.NewGuid().ToString(), AuthorID = 1, Title="This is an item description." }
            };
        }

        public async Task<bool> AddBookAsync(Book book)
        {
            books.Add(book);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            var oldBook = books.Where((Book arg) => arg.ISBN == book.ISBN).FirstOrDefault();
            books.Remove(oldBook);
            books.Add(book);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteBookAsync(string isbn)
        {
            var oldBook = books.Where((Book arg) => arg.ISBN == isbn).FirstOrDefault();
            books.Remove(oldBook);

            return await Task.FromResult(true);
        }

        public async Task<Book> GetBookAsync(string isbn)
        {
            return await Task.FromResult(books.FirstOrDefault(s => s.ISBN == isbn));
        }

        public async Task<IEnumerable<Book>> GetBookAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(books);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(books);
            //throw new NotImplementedException();
        }
    }
}
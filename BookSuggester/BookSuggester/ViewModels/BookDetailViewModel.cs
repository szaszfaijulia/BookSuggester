using BookSuggester.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookSuggester.ViewModels
{
    [QueryProperty(nameof(BookId), nameof(BookId))]
    class BookDetailViewModel : BaseViewModel
    {
        private string isbn;
        private int authorid;
        private string title;
        private int genreid;
        private int pubdate;
        public string ISBN { get; set; }

        public int AuthorID
        {
            get => authorid;
            set => SetProperty(ref authorid, value);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public int GenreID
        {
            get => genreid;
            set => SetProperty(ref genreid, value);
        }
        public int PubDate
        {
            get => pubdate;
            set => SetProperty(ref pubdate, value);
        }

        public string BookId
        {
            get
            {
                return isbn;
            }
            set
            {
                isbn = value;
                LoadBookId(value);
            }
        }

        public async void LoadBookId(string bookId)
        {
            try
            {
                var book = await DataStore.GetBookAsync(bookId);
                ISBN = book.ISBN;
                AuthorID = book.AuthorID;
                Title = book.Title;
                GenreID = book.GenreID;
                PubDate = book.PubDate;
            }
            catch (Exception)
            {
                Debug.WriteLine("Nem sikerült betölteni a könyvet");
            }
        }
    }
}

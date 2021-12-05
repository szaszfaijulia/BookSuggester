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
        private string author;
        private string title;
        private string publisher;
        private string subject;
        private int pubdate;
        public string ISBN { get; set; }

        public string Author
        {
            get => author;
            set => SetProperty(ref author, value);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public string Publisher
        {
            get => publisher;
            set => SetProperty(ref publisher, value);
        }
        public string Subject
        {
            get => subject;
            set => SetProperty(ref subject, value);
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
                Author = book.Author;
                Title = book.Title;
                /*Publisher = book.Publisher;
                Subject = book.Subject;
                PubDate = book.PubDate;*/
            }
            catch (Exception)
            {
                Debug.WriteLine("Nem sikerült betölteni a könyvet");
            }
        }
    }
}

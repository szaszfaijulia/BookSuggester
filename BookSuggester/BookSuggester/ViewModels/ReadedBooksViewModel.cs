using BookSuggester.Models;
using BookSuggester.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookSuggester.ViewModels
{
    public class ReadedBooksViewModel : BaseViewModel
    {
        private Book _selectedBook;

        public ObservableCollection<Book> Books { get; }
        public Command LoadBooksCommand { get; }
        public Command AddBookCommand { get; }
        public Command<Book> BookTapped { get; }

        public ReadedBooksViewModel()
        {
            Title = "Olvasott könyvek";
            Books = new ObservableCollection<Book>();
            LoadBooksCommand = new Command(async () => await ExecuteLoadBooksCommand());

            BookTapped = new Command<Book>(OnBookSelected);

            AddBookCommand = new Command(OnAddBook);
        }

        async Task ExecuteLoadBooksCommand()
        {
            IsBusy = true;

            try
            {
                Books.Clear();
                var books = await DataStore.GetBooksAsync(true);
                foreach (var book in books)
                {
                    Books.Add(book);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedBook = null;
        }

        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                SetProperty(ref _selectedBook, value);
                OnBookSelected(value);
            }
        }

        private async void OnAddBook(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnBookSelected(Book book)
        {
            if (book == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(BookDetailViewModel.BookId)}={book.ISBN}");
        }
    }
}
using BookSuggester.Models;
using BookSuggester.Views;
using BookSuggester.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using MvvmHelpers.Commands;
using MvvmHelpers;
using Command = MvvmHelpers.Commands.Command;

namespace BookSuggester.ViewModels
{
    public class SavdBooksViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Book> Book { get; set; }
        //public ObservableRangeCollection<Grouping<string, Book>> BookGroups { get; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<Book> RemoveCommand { get; }
        //public AsyncCommand<Book> SelectedCommand { get; }

        public SavdBooksViewModel()
        {
            Title = "Mentett könyvek";
            Book = new ObservableRangeCollection<Book>();
            //LoadBookCommand = new Command(async () => await ExecuteLoadBooksCommand());

            //BookTapped = new Command<Book>(OnBookSelected);

            Book = new ObservableRangeCollection<Book>();
            //BookGroups = new ObservableRangeCollection<Grouping<string, Book>>();


            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Book>(Remove);
            //SelectedCommand = new AsyncCommand<Book>(Selected);

            //bookService = DependencyService.Get<BookService>();
        }
        async Task Add()
        {
            var isbn = await App.Current.MainPage.DisplayPromptAsync("ISBN", "A könyv ISBN száma");
            var author = await App.Current.MainPage.DisplayPromptAsync("Szerző", "A könyv írója");
            var title = await App.Current.MainPage.DisplayPromptAsync("Cím", "A könyv címe");
            //var publisher = await App.Current.MainPage.DisplayPromptAsync("Kiadó", "Title of the book");
            //var subject = await App.Current.MainPage.DisplayPromptAsync("Műfaj", "Title of the book");
            //var pubdate = await App.Current.MainPage.DisplayPromptAsync("Kiadási év", "Title of the book");
            await BookService.AddBook(isbn, author, title);
            //await BookService.AddBook(isbn, author, title, publisher, subject, pubdate);
            await Refresh();
        }

        async Task Selected(Book book)
        {
            if (book == null)
                return;

            var route = $"{nameof(ItemDetailPage)}?BookId={book.Id}";
            await Shell.Current.GoToAsync(route);
        }

        async Task Remove(Book book)
        {
            await BookService.RemoveBook(book.Id);
            await Refresh();
        }

        async Task Refresh()
        {
            IsBusy = true;

//#if DEBUG
//            await Task.Delay(500);
//#endif

            Book.Clear();

            var books = await BookService.GetBook();

            Book.AddRange(books);

            IsBusy = false;
        }
    }
}
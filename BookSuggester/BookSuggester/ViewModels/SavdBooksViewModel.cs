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
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<Book> RemoveCommand { get; }

        public SavdBooksViewModel()
        {
            Title = "Mentett könyvek";
            Book = new ObservableRangeCollection<Book>();

            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Book>(Remove);
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

        public async Task Remove(Book book)
        {
            await BookService.RemoveBook(book.Id);
            await Refresh();
        }

        public async Task Refresh()
        {
            IsBusy = true;

            //await Task.Delay(500);

            Book.Clear();

            var books = await BookService.GetBook();

            Book.AddRange(books);

            IsBusy = false;
        }
    }
}
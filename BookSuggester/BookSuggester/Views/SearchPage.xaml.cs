using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//using Google.Apis.Services;   // ----- 1. -----
using BookSuggester.Services;

namespace BookSuggester.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }
        /*public static BookService service = new BooksService(     // ----- 1. -----
            new BaseClientService.Initializer
            {
                ApplicationName = "ISBNBookSearch",
                ApiKey = "abcdefghijklmnopqrstuvwxyz",
            });*/
        private async void SearchButton_Clicked(object sender, EventArgs e)
        {
            // Könyvek lekérése GoogleBooks-ból

            //await SearchISBN((string)sender);  // object ??       // ----- 1. -----


            // Könyvek mentése adatbázisba ?
        }

        /*public static async Task<Volume> SearchISBN(string isbn)   // ----- 1. -----
        {
            //Console.WriteLine(“Executing a book search request…”);
            var result = await service.Volumes.List(isbn).ExecuteAsync();
            if (result != null && result.Items != null)
            {
                var item = result.Items.FirstOrDefault();
                return item;
            }
            return null;
        }*/

        /*function getBookDetails(isbn)         // ----- 2. ----- 
        {
            // Query the book database by ISBN code.
            isbn = isbn || '9781451648546'; // Steve Jobs book

            var url = 'https://www.googleapis.com/books/v1/volumes?q=isbn:' + isbn;

            var response = UrlFetchApp.fetch(url);
            var results = JSON.parse(response);

            if (results.totalItems)
            {
                // There'll be only 1 book per ISBN
                var book = results.items[0];

                var title = book['volumeInfo']['title'];
                var subtitle = book['volumeInfo']['subtitle'];
                var authors = book['volumeInfo']['authors'];
                var printType = book['volumeInfo']['printType'];
                var pageCount = book['volumeInfo']['pageCount'];
                var publisher = book['volumeInfo']['publisher'];
                var publishedDate = book['volumeInfo']['publishedDate'];
                var webReaderLink = book['accessInfo']['webReaderLink'];

                // For debugging
                Logger.log(book);
            }
        }*/

    }
}
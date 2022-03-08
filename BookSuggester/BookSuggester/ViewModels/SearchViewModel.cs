﻿using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookSuggester.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        public AsyncCommand SearchCommand { get; }
        public SearchViewModel()
        {
            Title = "Keresés";

            SearchCommand = new AsyncCommand(Search);
        }

        private Task Search()
        {
            throw new NotImplementedException();
        }

        function getBookDetails(isbn)
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
        }
    }
}

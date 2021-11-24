using BookSuggester.ViewModels;
using System;
using System.Collections.Generic;
using BookSuggester.Models;
using BookSuggester.Views;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookSuggester.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReadedBooksPage : ContentPage
    {
        ReadedBooksViewModel _viewModel;
        public ReadedBooksPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ReadedBooksViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
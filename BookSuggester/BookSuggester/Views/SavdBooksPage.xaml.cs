using System;
using System.Collections.Generic;
using BookSuggester.Models;
using BookSuggester.ViewModels;
using BookSuggester.Views;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;
using BookSuggester.Services;

namespace BookSuggester.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SavdBooksPage : ContentPage
    {
        SavdBooksViewModel _viewModel;
        public SavdBooksPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new SavdBooksViewModel();
        }

        /*private async void Button_Clicked(object sender, EventArgs e)
        {
            await BookService.RemoveBook(id);
        }*/
    }
}
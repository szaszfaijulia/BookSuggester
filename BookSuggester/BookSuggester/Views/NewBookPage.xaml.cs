using BookSuggester.Models;
using BookSuggester.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookSuggester.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewBookPage : ContentPage
    {
        public Book Item { get; set; }

        public NewBookPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}
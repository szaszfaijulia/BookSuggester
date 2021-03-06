using BookSuggester.Models;
using BookSuggester.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookSuggester.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Book Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}
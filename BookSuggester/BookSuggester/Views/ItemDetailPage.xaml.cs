using BookSuggester.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BookSuggester.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
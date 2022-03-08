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
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _viewModel.Refresh();
        }

        //private async void Delete_Button_Clicked(object sender, EventArgs e) //könyv törlése  // NEM KELL
        //{
            /*Button selectedItem = (Button)sender;
            var id = selectedItem.CommandParameter.ToString();
            await SavdBooksViewModel.Remove(id);*/

            /*Button button = (Button)sender;
            string buttonId = button.ID;*/

            /*Button EditButton = (Button)e.Source;
            int id = Convert.ToInt32(EditButton.Tag);
            //do your stuff */

            //await BookService.RemoveBook(id);
            //await SavdBooksViewModel.Remove(book);

        //}
    }
}
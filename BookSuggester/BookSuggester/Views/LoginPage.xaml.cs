using BookSuggester.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookSuggester.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //this.BindingContext = new LoginViewModel();
        }
        /* protected override async void OnAppearing()
        {
            base.OnAppearing();
            var loggedin = true; //adatbázisból
            if(loggedin)
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }*/

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync($"//{nameof(LoginPage)}/{nameof(RegistrationPage)}");
            await Shell.Current.GoToAsync($"//{nameof(RegistrationPage)}");
        }
    }
}
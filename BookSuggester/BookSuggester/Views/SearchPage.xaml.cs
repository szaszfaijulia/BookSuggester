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
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }
        private /*async*/ void SearchButton_Clicked(object sender, EventArgs e)
        {
            //Könyvek lekérése GoogleBooks-ból


            //Könyvek mentése adatbázisba ?
        }
    }
}
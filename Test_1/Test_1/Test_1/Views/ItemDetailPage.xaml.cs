using System.ComponentModel;
using Test_1.ViewModels;
using Xamarin.Forms;

namespace Test_1.Views
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
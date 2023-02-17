using System;
using System.Collections.Generic;
using System.ComponentModel;
using Test_1.Models;
using Test_1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test_1.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}
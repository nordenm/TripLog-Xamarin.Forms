using System;
using System.Collections.Generic;
using System.Linq;
using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;
using Xamarin.Forms;

namespace TripLog.Views
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel ViewModel => BindingContext as MainPageViewModel;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Initialize MainViewModel
            ViewModel?.Init();
        }
    }
}
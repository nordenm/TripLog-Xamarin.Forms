using System;
using System.Collections.Generic;
using System.Linq;
using TripLog.Models;
using TripLog.ViewModels;
using Xamarin.Forms;

namespace TripLog.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel();
        }

        void New_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewEntryPage());
        }

        async void Trips_SelectionChanged(object s, SelectionChangedEventArgs e)
        {
            var trip = (TripLogEntry)e.CurrentSelection.FirstOrDefault();

            if (trip != null)
            {
                await Navigation.PushAsync(new DetailPage(trip));
            }

            // Clear selection
            trips.SelectedItem = null;
        }
    }
}
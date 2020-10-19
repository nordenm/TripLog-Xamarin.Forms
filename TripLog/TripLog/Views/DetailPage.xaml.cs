using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using TripLog.Models;
using TripLog.ViewModels;

namespace TripLog.Views
{
    public partial class DetailPage : ContentPage
    {
        DetailPageViewModel ViewModel => BindingContext as DetailPageViewModel;

        public DetailPage(TripLogEntry entry)
        {
            InitializeComponent();            

            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(
                    ViewModel.Entry.Latitude,
                    ViewModel.Entry.Longitude),
                Distance.FromMiles(.5)));

            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = ViewModel.Entry.Title,
                Position = new Position(ViewModel.Entry.Latitude, ViewModel.Entry.Longitude)
            });
        }
    }
}
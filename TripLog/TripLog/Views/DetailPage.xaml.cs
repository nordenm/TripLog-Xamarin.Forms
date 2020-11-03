﻿using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using TripLog.ViewModels;
using TripLog.Services;

namespace TripLog.Views
{
    public partial class DetailPage : ContentPage
    {
        DetailPageViewModel ViewModel => BindingContext as DetailPageViewModel;

        public DetailPage()
        {
            InitializeComponent();

            BindingContext = new DetailPageViewModel(DependencyService.Get<INavService>());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel != null)
            {
                ViewModel.PropertyChanged += OnViewModelPropertyChanged;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (ViewModel != null)
            {
                ViewModel.PropertyChanged -= OnViewModelPropertyChanged;
            }
        }

        void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(DetailPageViewModel.Entry))
            {
                UpdateMap();
            }
        }

        void UpdateMap()
        {
            if (ViewModel.Entry == null)
            {
                return;
            }

            // Center the map around the log entry's location
            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(ViewModel.Entry.Latitude, ViewModel.Entry.Longitude),
                Distance.FromMiles(.5)));

            // Place a pin on the map for the log entry's location
            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = ViewModel.Entry.Title,
                Position = new Position(ViewModel.Entry.Latitude, ViewModel.Entry.Longitude)
            });
        }
    }
}
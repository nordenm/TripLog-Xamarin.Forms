using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using TripLog.ViewModels;

namespace TripLog.Views
{
    public partial class NewEntryPage : ContentPage
    {
        NewEntryPageViewModel ViewModel => BindingContext as NewEntryPageViewModel;

        public NewEntryPage()
        {
            InitializeComponent();

            BindingContextChanged += Page_BindingContextChanged;

            BindingContext = new NewEntryPageViewModel();
        }

        private void Page_BindingContextChanged(object sender, EventArgs e)
        {
            ViewModel.ErrorsChanged += ViewModel_ErrorsChanged;
        }

        private void ViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            var propHasErrors = (ViewModel.GetErrors(e.PropertyName) as List<string>)?.Any() == true;

            switch (e.PropertyName)
            {
                case nameof(ViewModel.Title):
                    title.LabelColor = propHasErrors ? Color.Red : Color.Black;
                    break;
                case nameof(ViewModel.Rating):
                    rating.LabelColor = propHasErrors ? Color.Red : Color.Black;
                    break;
                default:
                    break;
            }
        }
    }
}
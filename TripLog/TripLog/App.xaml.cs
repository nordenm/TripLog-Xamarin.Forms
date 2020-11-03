using System;
using TripLog.Services;
using TripLog.ViewModels;
using TripLog.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TripLog
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var mainPage = new NavigationPage(new MainPage());
            var navService = DependencyService.Get<INavService>() as XamarinFormsNavService;

            navService.XamarinFormsNav = mainPage.Navigation;
            navService.RegisterViewMapping(typeof(MainPageViewModel), typeof(MainPage));
            navService.RegisterViewMapping(typeof(DetailPageViewModel), typeof(DetailPage));
            navService.RegisterViewMapping(typeof(NewEntryPageViewModel), typeof(NewEntryPage));

            MainPage = mainPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

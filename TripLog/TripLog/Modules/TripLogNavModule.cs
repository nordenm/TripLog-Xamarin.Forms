using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using TripLog.Services;
using TripLog.ViewModels;
using TripLog.Views;

namespace TripLog.Modules
{
    public class TripLogNavModule : NinjectModule
    {
        public override void Load()
        {
            var navService = new XamarinFormsNavService();

            // Register view mappings
            navService.RegisterViewMapping(typeof(MainPageViewModel), typeof(MainPage));
            navService.RegisterViewMapping(typeof(DetailPageViewModel), typeof(DetailPage));
            navService.RegisterViewMapping(typeof(NewEntryPageViewModel), typeof(NewEntryPage));

            Bind<INavService>().ToMethod(x => navService).InSingletonScope();
        }
    }
}

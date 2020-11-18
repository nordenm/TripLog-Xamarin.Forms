using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using TripLog.ViewModels;

namespace TripLog.Modules
{
    public class TripLogCoreModule : NinjectModule
    {
        public override void Load()
        {
            // ViewModels
            Bind<MainPageViewModel>().ToSelf();
            Bind<DetailPageViewModel>().ToSelf();
            Bind<NewEntryPageViewModel>().ToSelf();
        }
    }
}

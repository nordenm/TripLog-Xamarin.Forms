using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using TripLog.iOS.Services;
using TripLog.Services;
using UIKit;

namespace TripLog.iOS.Modules
{
    public class TripLogPlatformModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<ILocationService>().To<LocationService>().InSingletonScope();
        }
    }
}
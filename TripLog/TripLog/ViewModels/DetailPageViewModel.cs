using System;
using System.Collections.Generic;
using System.Text;
using TripLog.Models;
using TripLog.Services;

namespace TripLog.ViewModels
{
    public class DetailPageViewModel : BaseViewModel<TripLogEntry>
    {
        public DetailPageViewModel(INavService navService) : base(navService)
        {            
        }

        public override void Init(TripLogEntry parameter)
        {
            Entry = parameter;
        }

        private TripLogEntry _entry;
        public TripLogEntry Entry
        {
            get { return _entry; }
            set
            {
                _entry = value;
                OnPropertyChanged();
            }
        }

    }
}

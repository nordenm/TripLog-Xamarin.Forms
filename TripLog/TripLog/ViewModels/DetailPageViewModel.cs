using System;
using System.Collections.Generic;
using System.Text;
using TripLog.Models;

namespace TripLog.ViewModels
{
    public class DetailPageViewModel : BaseViewModel
    {
        public DetailPageViewModel(TripLogEntry entry)
        {
            Entry = entry;
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

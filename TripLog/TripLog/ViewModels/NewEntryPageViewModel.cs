using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TripLog.Models;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
    public class NewEntryPageViewModel : BaseValidationViewModel
    {
        public NewEntryPageViewModel()
        {
            Date = DateTime.Today;
            Rating = 1;
        }

        #region Attributes

        private string _title;
        private double _latitude;
        private double _longitude;
        private DateTime _date;
        private int _rating;
        private string _notes;
        private ICommand _saveCommand;

        #endregion

        #region Properties

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                Validate(() => !string.IsNullOrWhiteSpace(_title), "Title must be provided.");
                OnPropertyChanged();
            }
        }

        public double Latitude
        {
            get { return _latitude; }
            set
            {
                _latitude = value;
                OnPropertyChanged();
            }
        }

        public double Longitude
        {
            get { return _longitude; }
            set
            {
                _longitude = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public int Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                Validate(() => _rating >= 1 && _rating <=5, "Rating must be between 1 and 5.");
                OnPropertyChanged();
            }
        }

        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand SaveCommand
        {
            get
            {
                _saveCommand = _saveCommand ?? new Command(SaveCommandExecute);
                return _saveCommand;
            }
        }

        #endregion

        #region Methods

        private void SaveCommandExecute()
        {
            if (CanSave())
            {
                var newItem = new TripLogEntry
                {
                    Title = Title,
                    Latitude = Latitude,
                    Longitude = Longitude,
                    Date = Date,
                    Rating = Rating,
                    Notes = Notes
                };

                // TODO: Persist entry in a later chapter
            }
        }

        private bool CanSave()
        {
            return !string.IsNullOrEmpty(Title) && !HasErrors;
        }

        #endregion
    }
}

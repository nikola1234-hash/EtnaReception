using System;
using Reception.Model;

namespace Reception.Wrappers
{
    public class SearchWrapper : ModelWrapper
    {
        public event Action StateChanged;

        private DateTime _startDate = DateTime.Now.Date;
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                SetProperty(ref _startDate, value);
                Validation(nameof(StartDate));
                RaisePropertyChanged(nameof(HasErrors));
                RaiseEnabledButton();
                OnStateChange();
            }
        }
        private void OnStateChange()
        {
            StateChanged?.Invoke();
        }
        private void RaiseEnabledButton()
        {
            IsEnabled = !HasErrors;
        }

        private void Validation(string propertyName)
        {
            ClearErrors(propertyName);
            switch (propertyName)
            {
                case nameof(StartDate):
                    if (StartDate.Date < DateTime.Now.Date)
                    {
                        AddErrors(propertyName, "Rezervacija ne moze da se upisuje retroaktivno.");
                    }
                    break;
                case nameof(EndDate):
                    if (EndDate.Date < DateTime.Now.Date)
                    {
                        AddErrors(propertyName,
                            $"Nije dobro upisan datum odlaska!" +
                            $" Danasnji datum je {DateTime.Now.Date}," +
                            $" izabran datum je {EndDate.Date}");
                    }
                    break;
                case nameof(NumberOfPeople):
                    if (NumberOfPeople > 10)
                    {
                        AddErrors(propertyName, "Da li imate smestaj za ovoliko ljudi?");
                    }
                    if (NumberOfPeople == 0)
                    {
                        AddErrors(propertyName, "Broj osoba mora biti veci od nula!");
                    }
                    break;
            }
        }
        private DateTime _endDate = DateTime.Now.Date.AddDays(2);
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                SetProperty(ref _endDate, value);
                Validation(nameof(EndDate));
                RaisePropertyChanged(nameof(HasErrors));
                RaiseEnabledButton();
                OnStateChange();
            }
        }
        private int _numberOfPeople;
        public int NumberOfPeople
        {
            get { return _numberOfPeople; }
            set
            {
                SetProperty(ref _numberOfPeople, value);
                Validation(nameof(NumberOfPeople));
                RaisePropertyChanged(nameof(HasErrors));
                RaiseEnabledButton();
                OnStateChange();
            }
        }


        private bool _isEnabled;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                SetProperty(ref _isEnabled, value);
            }
        }

    }
}

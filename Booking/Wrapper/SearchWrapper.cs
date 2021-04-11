using Booking.Model;
using System;

namespace Booking.Wrapper
{
    public class SearchWrapper : ModelWrapper<Search>
    {
        public SearchWrapper(Search model) : base(model)
        {

        }

        public DateTime StartDate
        {
            get { return Model.StartDate; }
            set
            {
                if (!Equals(Model.StartDate, value))
                {
                    Model.StartDate = value;
                    Validation(nameof(StartDate));
                    RaisePropertyChanged(nameof(StartDate));
                    
                }
            }
        }

        private void Validation(string propertyName)
        {
            ClearErrors(propertyName);
            if(StartDate.Date < DateTime.Now.Date)
            {
                AddErrors(propertyName, "Rezervacija ne moze da se upisuje retroaktivno.");
            }
            if(EndDate.Date < DateTime.Now.Date)
            {
                AddErrors(propertyName,
                    $"Nije dobro upisan datum odlaska!" +
                    $" Danasnji datum je {DateTime.Now.Date}," +
                    $" izabran datum je {EndDate.Date}");
            }
            if(NumberOfPeople > 10)
            {
                AddErrors(propertyName, "Da li imate smestaj za ovoliko ljudi?");
            }
            if(NumberOfPeople == 0)
            {
                AddErrors(propertyName, "Broj osoba mora biti veci od nula!");
            }
        }

        public DateTime EndDate
        {
            get { return Model.EndDate; }
            set
            {
                if(!Equals(Model.EndDate, value))
                {
                    Model.EndDate = value;
                    RaisePropertyChanged(nameof(EndDate));
                }
            }
        }
        public int NumberOfPeople
        {
            get { return Model.NumberOfPeople; }
            set
            {
                if(!Equals(Model.NumberOfPeople, value))
                {
                    Model.NumberOfPeople = value;
                    RaisePropertyChanged(nameof(NumberOfPeople));
                }
            }
        }
        public int SelectedType
        {
            get { return Model.SelectedType; }
            set
            {
                if(!Equals(Model.SelectedType, value))
                {
                    Model.SelectedType = value;
                    RaisePropertyChanged(nameof(SelectedType));
                }
            }
        }
    }
}

﻿using Booking.Model;
using System;

namespace Booking.Wrapper
{
    public class SearchWrapper : ModelWrapper
    {
        private DateTime _testDate;

        public DateTime TestDate
        {
            get { return _testDate; }
            set
            {
                SetProperty(ref _testDate, value);
            }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                SetProperty(ref _startDate, value);
                Validation(nameof(StartDate));
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
        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                SetProperty(ref _endDate, value);
                Validation(nameof(EndDate));
             
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
            }
        }
        private int _selectedType;
        public int SelectedType
        {
            get { return _selectedType; }
            set
            {
                SetProperty(ref _selectedType, value);
            }
        }
    }
}
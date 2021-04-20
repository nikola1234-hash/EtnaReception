using Booking.Model;
using BookSoft.BLL.Validation;
using System;

namespace Booking.Wrapper
{
    public class GuestWrapper : ModelWrapper
    {
        public event Action StateChanged;

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set 
            {
                SetProperty(ref _firstName, value);
                //ValidateProperty(nameof(FirstName));
                OnStateChanged();
            }
        }

        private void ValidateProperty(string propertyName)
        {
            ClearErrors(propertyName);
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                AddErrors(propertyName, "Ovo polje je obavezno!");
            }
            if (string.IsNullOrWhiteSpace(LastName))
            {
                AddErrors(propertyName, "Ovo polje je obavezno!");
            }
            if (string.IsNullOrWhiteSpace(Phone))
            {
                AddErrors(propertyName, "Ovo polje je obavezno!");
            }
            if(!NumbersValidation.Validate(Phone))
            {
                AddErrors(propertyName, "Broj telefona moze da sadrzi samo brojeve!");
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set 
            {
                SetProperty(ref _lastName, value);
                //ValidateProperty(nameof(LastName));
                OnStateChanged();
            }
        }
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                SetProperty(ref _phone, value);
                //ValidateProperty(nameof(Phone));
                OnStateChanged();
            }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set 
            { 
                SetProperty(ref _email, value);
                OnStateChanged();
            }
        }
        private string _address;
        public string Address
        {
            get { return _address; }
            set 
            {
                SetProperty(ref _address, value);
                OnStateChanged();
            }
        }
        private string _jmbg;
        public string Jmbg
        {
            get { return _jmbg; }
            set 
            {
                SetProperty(ref _jmbg, value);
                OnStateChanged();
            }
        }
        private string _details;
        public string Details
        {
            get { return _details; }
            set { SetProperty(ref _details, value); }
        }
        public void OnStateChanged()
        {
            StateChanged?.Invoke();
        }
    }
}

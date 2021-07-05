using BookSoft.BLL.Validation;
using System;
using System.Windows.Documents;
using Reception.Model;

namespace Reception.Wrappers
{
    public delegate void Notify();
    public class GuestWrapper : ModelWrapper
    {
        public event Notify StateChanged;

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set 
            {
                SetProperty(ref _firstName, value);
                ValidateProperty(nameof(FirstName));
                OnStateChanged();
            }
        }

        private void ValidateProperty(string propertyName)
        {
            ClearErrors(propertyName);
            switch (propertyName)
            {
                case nameof(FirstName):
                    if (string.IsNullOrEmpty(FirstName))
                    {
                        AddErrors(propertyName, "Ovo polje je obavezno.");
                    }
                    if(FirstName.Length < 3)
                    {
                        AddErrors(propertyName, "Ime mora imati minimum 3 slova.");
                    }

                    break;
                case nameof(LastName):
                    if (string.IsNullOrEmpty(LastName))
                    {
                        AddErrors(propertyName, "Ovo polje je obavezno.");
                    }
                    if(LastName.Length < 3)
                    {
                        AddErrors(propertyName, "Prezime mora imati vise od 3 karaktera.");
                    }
                    break;
                case nameof(Phone):
                    if (string.IsNullOrEmpty(Phone))
                    {
                        AddErrors(propertyName, "Broj telefona je obavezno polje.");
                    }
                    if (!NumbersValidation.Validate(Phone))
                    {
                        AddErrors(propertyName, "Broj telefona se izrazava u brojevima.");
                    }
                    break;
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set 
            {
                SetProperty(ref _lastName, value);
                ValidateProperty(nameof(LastName));
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
                ValidateProperty(nameof(Phone));
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

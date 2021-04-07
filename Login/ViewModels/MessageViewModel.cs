using Prism.Mvvm;

namespace Login.ViewModels
{
    public class MessageViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                SetProperty(ref _message, value);
                RaisePropertyChanged(nameof(HasMessage));

            }
        }
        public bool HasMessage => !string.IsNullOrEmpty(_message);
    }
}
using Prism.Mvvm;

namespace EtnaReception.Desktop.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Etna Reception";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}

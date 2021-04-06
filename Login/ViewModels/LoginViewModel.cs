using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Login.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        public DelegateCommand<object> LoginCommand { get; }
        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand<object>(OnLogin);
        }

        private void OnLogin(object obj)
        {
            throw new NotImplementedException();
        }
    }
}

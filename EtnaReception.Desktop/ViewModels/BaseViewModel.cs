using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace EtnaReception.Desktop.ViewModels
{
    public class BaseViewModel : BindableBase, IDisposable
    {
        bool disposing = false;

        protected virtual void Dispose(bool disposing)
        {

        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

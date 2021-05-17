using System;
using System.Net.Http.Headers;
using BookSoft.Domain.Models;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Syncfusion.Windows.Controls;

namespace Reception.Dialogs
{
    public class EditReservationDialogViewModel : BindableBase, IDialogAware
    {
        #region PropertiesRegion
        private bool _isDirty;
        public bool IsDirty
        {
            get { return _isDirty; }
            set { SetProperty(ref _isDirty, value); }
        }

        private DateTime _startDate;

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate > DateTime.MinValue)
                {
                    SetIsDirty(ref _startDate, value);
                }
             
                SetProperty(ref _startDate, value);
            }
        }


        #endregion

        #region PrivateMethods

        private void SetIsDirty<T>(ref T name, T value)
        {
            if (!name.Equals(value))
            {
                IsDirty = true;
            }
            
        }

        #endregion


        #region Constructor

        public EditReservationDialogViewModel()
        {

        }

        #endregion


        #region DialogImplementation
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            var t = parameters.GetValue<RoomScheduler>("roomScheduler");
            StartDate = (DateTime)t.StartDate;
        }

        public string Title => "Izmeni";
        public event Action<IDialogResult> RequestClose;
    }


    #endregion

}

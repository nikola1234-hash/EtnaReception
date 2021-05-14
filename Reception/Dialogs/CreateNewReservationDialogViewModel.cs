using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using BookSoft.BLL.Services;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Reception.Dialogs
{
    public class CreateNewReservationDialogViewModel : BindableBase, IDialogAware
    {
        private int _roomId;

        public int  RoomId
        {
            get { return _roomId; }
            set { SetProperty(ref _roomId, value); }
        }

        private DateTime _startDate;

        public DateTime StartDate
        {
            get { return _startDate; }
            set { SetProperty(ref _startDate, value); }
        }

        private DateTime _endDate;

        public DateTime EndDate
        {
            get { return _endDate; }
            set { SetProperty(ref _endDate, value); }
        }

        private readonly IReceptionService _receptionService;
        public CreateNewReservationDialogViewModel(IReceptionService receptionService)
        {
            _receptionService = receptionService;
        }

        public bool CanCloseDialog()
        {
            throw new NotImplementedException();
        }

        public void OnDialogClosed()
        {
            throw new NotImplementedException();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            StartDate = parameters.GetValue<DateTime>("dolazak");
        }

        public string Title => "Upisi rezervaciju";
        public event Action<IDialogResult> RequestClose;
    }
}

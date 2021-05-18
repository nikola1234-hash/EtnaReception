using System;
using System.Collections.ObjectModel;
using BookSoft.BLL.Services;
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
            get => _isDirty;
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

        private ObservableCollection<StatusModel> _statusList;

        public ObservableCollection<StatusModel> StatusList
        {
            get { return _statusList; }
            set { SetProperty(ref _statusList, value); }
        }

        public int ReservationId { get; set; }
        private DateTime _endDate;

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                if (_endDate > DateTime.MinValue)
                {
                    SetIsDirty(ref _endDate, value);
                }
                SetProperty(ref _endDate, value);
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

        private readonly IReceptionService _receptionService;
        private readonly IEditScheduleService _editScheduleService;

        public EditReservationDialogViewModel(IEditScheduleService editScheduleService, IReceptionService receptionService)
        {
            _editScheduleService = editScheduleService;
            _receptionService = receptionService;
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
            EndDate = (DateTime) t.EndDate;
            ReservationId = t.ReservationId;
            StatusList = new ObservableCollection<StatusModel>(_receptionService.LoadStatus()); 
        }

        public string Title => "Izmeni";
        public event Action<IDialogResult> RequestClose;
    }


    #endregion

}

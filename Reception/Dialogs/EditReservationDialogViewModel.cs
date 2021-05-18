using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Windows.Input;
using BookSoft.BLL.Services;
using BookSoft.Domain.Models;
using Prism.Commands;
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

        private int _selectedStatusIndex;

        public int SelectedStatusIndex
        {
            get { return _selectedStatusIndex; }
            set { SetProperty(ref _selectedStatusIndex, value); }
        }
        public int StayTypeId { get; set; }
        private StatusModel _selectedStatusModel;

        public StatusModel SelectedStatusModel
        {
            get { return _selectedStatusModel; }
            set
            {
                SetProperty(ref _selectedStatusModel, value);
            }
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

        private IEnumerable<RoomResource> _rooms;

        public IEnumerable<RoomResource> Rooms
        {
            get { return _rooms; }
            set { SetProperty(ref _rooms, value); }
        }

        private IEnumerable<StayType> _stayTypes;

        public IEnumerable<StayType> StayTypes
        {
            get { return _stayTypes; }
            set { SetProperty(ref _stayTypes, value); }
        }

        private StayType _selectedStayType;

        public StayType SelectedStayType
        {
            get { return _selectedStayType; }
            set { SetProperty(ref _selectedStayType, value); }
        }

        private RoomResource _selectedRoom;

        public RoomResource SelectedRoom
        {
            get { return _selectedRoom; }
            set { SetProperty(ref _selectedRoom, value); }
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
        private readonly IStayTypeService _stayTypeService;
        public EditReservationDialogViewModel(IEditScheduleService editScheduleService,
            IReceptionService receptionService, IStayTypeService stayTypeService)
        {
            _editScheduleService = editScheduleService;
            _receptionService = receptionService;
            _stayTypeService = stayTypeService;
            UpdateCommand = new DelegateCommand(UpdateCommandExecute, CanUpdateExecute).ObservesCanExecute(()=> IsDirty);
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
            var p = parameters.GetValue<RoomScheduler>("roomScheduler");
            StartDate = (DateTime) p.StartDate;
            EndDate = (DateTime) p.EndDate;
            ReservationId = p.ReservationId;
            StayTypeId = p.StayTypeId;
            Initialize();

        }

        private void Initialize()
        {
            //TODO: Check this out
            var statusList = _receptionService.LoadStatus();
            StatusList = new ObservableCollection<StatusModel>(statusList);
            var status = _receptionService.LoadStatusByReservationId(ReservationId);
            SelectedStatusModel = _receptionService.LoadStatus(status.Id).FirstOrDefault();
            var types = _stayTypeService.GetAllTypes();
            StayTypes = new ObservableCollection<StayType>(types);
            SelectedStayType = _stayTypeService.GetById(StayTypeId);
            SelectedStatusIndex = status.Id - 1;
            var rooms = _receptionService.LoadRoomResource();
            Rooms = new ObservableCollection<RoomResource>(rooms);

        }


        public string Title => "Izmeni";
        public event Action<IDialogResult> RequestClose;



        #endregion

        #region Commands

        public DelegateCommand UpdateCommand { get; }
        private void UpdateCommandExecute()
        {
            //Update db
        }
        private bool CanUpdateExecute()
        {
            return IsDirty;
        }
        #endregion

    }
}
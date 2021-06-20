using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using BookSoft.BLL.Services;
using BookSoft.Domain.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reception.Services.Facade;
using Syncfusion.Windows.Controls;

/// <summary>
/// TODO IsDirty ne dodeljuje value kako treba Date i na Selected room se kako treba 3.06
/// </summary>

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
                if (_startDate <= DateTime.MinValue)
                {
                    SetProperty(ref _startDate, value);
                }
                else
                {
                    IsDirty = SetProperty(ref _startDate, value);
                }
              
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
                if (_endDate < DateTime.MinValue)
                {
                    SetProperty(ref _endDate, value);
                }
                IsDirty = SetProperty(ref _endDate, value);
            }
        }

        private IEnumerable<RoomResource> _rooms;

        public IEnumerable<RoomResource> Rooms
        {
            get { return _rooms; }
            set
            {
                SetProperty(ref _rooms, value);
            }
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
        private RoomResource _previousSelectedRoom;
        private int _persons;

        public int Persons
        {
            get { return _persons; }
            set { SetProperty(ref _persons, value); }
        }
        public RoomResource SelectedRoom
        {
            get { return _selectedRoom; }
            set
            {
                if (_selectedRoom is null)
                {
                    SetProperty(ref _selectedRoom, value);
                }
                else
                {
                    IsDirty = SetProperty(ref _selectedRoom, value);
                }

            }
        }

        private int _selectedRoomIndex;

        public int SelectedRoomIndex
        {
            get { return _selectedRoomIndex; }
            set { SetProperty(ref _selectedRoomIndex, value); }
        }

        private int _selectedStayTypeInde;

        public int SelectedStayTypeIndex
        {
            get { return _selectedStayTypeInde; }
            set { SetProperty(ref _selectedStayTypeInde, value); }
        }
        #endregion

        #region PrivateMethods



        #endregion


        #region Constructor

        private readonly IReceptionService _receptionService;
        private readonly IEditScheduleService _editScheduleService;
        private readonly IStayTypeService _stayTypeService;
        private readonly IUpdateReservationFacade _updateReservationFacade;
        public EditReservationDialogViewModel(IEditScheduleService editScheduleService,
            IReceptionService receptionService, IStayTypeService stayTypeService, IUpdateReservationFacade updateReservationFacade)
        {
            _editScheduleService = editScheduleService;
            _receptionService = receptionService;
            _stayTypeService = stayTypeService;
            _updateReservationFacade = updateReservationFacade;
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
            var statusList = _receptionService.LoadStatus().ToList();
            StatusList = new ObservableCollection<StatusModel>(statusList);

            var status = _receptionService.LoadStatusByReservationId(ReservationId);
            SelectedStatusModel = _receptionService.LoadStatus(status.Id).FirstOrDefault();
            
            LoadStayTypes(statusList, status);

            LoadRooms();
        }

        private void LoadRooms()
        {
            var rooms = _receptionService.LoadRoomResource().ToList();
            Rooms = new ObservableCollection<RoomResource>(rooms);
            RoomReservation roomReservationDetails = _editScheduleService.LoadRoomReservationDetails(ReservationId);
            SelectedRoomIndex = rooms.FindIndex(c => c.Id == roomReservationDetails.RoomId);
            //Populate person TextBox
            Persons = roomReservationDetails.Persons;

            
        }

        private void LoadStayTypes(List<StatusModel> statusList, StatusModel status)
        {
            var types = _stayTypeService.GetAllTypes().ToList();
            StayTypes = new ObservableCollection<StayType>(types);

            SelectedStayType = _stayTypeService.GetById(StayTypeId);
            SelectedStayTypeIndex = types.FindIndex(i => i.Id == StayTypeId);
            SelectedStatusIndex = statusList.FindIndex(s => s.Id == status.Id);
            
        }


        public string Title => "Izmeni";
        public event Action<IDialogResult> RequestClose;



        #endregion

        #region Commands

        public DelegateCommand UpdateCommand { get; }
        private void UpdateCommandExecute()
        {   
                //TODO:
            //Update db
            var updateStatus = _updateReservationFacade.UpdateReservation(StartDate, EndDate, ReservationId, SelectedStatusModel.Id,
                SelectedRoom.Id, SelectedStayType.Id, Persons);
            if (updateStatus == UpdateStatus.Error)
            {
                MessageBox.Show("Greska u cuvanju podataka!");
            }

            if (updateStatus == UpdateStatus.Done)
            {
                MessageBox.Show("Uspesno izmenjen zapis.");
                Close();
            }
        }
        private bool CanUpdateExecute()
        {
            return IsDirty;
        }
        #endregion

        private void Close()
        {
            RequestClose?.Invoke(null);
        }
    }
}
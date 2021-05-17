using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using BookSoft.BLL.Services;
using BookSoft.DAL.Exceptions;
using BookSoft.Domain.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Reception.Dialogs
{
    public delegate void DateChange();
    public delegate void LoadDialog();
    public class CreateNewReservationDialogViewModel : BindableBase, IDialogAware
    {
        #region Fields Region

        public event DateChange DateChanged;
        public event LoadDialog Initialize;
        private bool _isDetailsVisible;
        private bool _isRoomSelected;
        private bool _isStayTypeSelected;
        private bool _isPeopleNumberValid;
        

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        private string _telephone;

        public string Telephone
        {
            get { return _telephone; }
            set { SetProperty(ref _telephone, value); }
        }

        private string _emailAddress;

        public string EmailAddress
        {
            get { return _emailAddress; }
            set { SetProperty(ref _emailAddress, value); }
        }

        private int _peopleNumber;

        public int PeopleNumber
        {
            get { return _peopleNumber; }
            set
            {
                SetProperty(ref _peopleNumber, value);
                OnSearchParametersChange();
            }
        }


        public bool IsPeopleNumberValid
        {
            get { return _isPeopleNumberValid; }
            set { SetProperty(ref _isPeopleNumberValid, value); }
        }

        public bool IsStayTypeSelected
        {
            get { return _isStayTypeSelected; }
            set { SetProperty(ref _isStayTypeSelected, value); }
        }
        public bool IsRoomSelected
        {
            get { return _isRoomSelected; }
            set { SetProperty(ref _isRoomSelected, value); }
        }

        public bool IsDetailsVisible
        {
            get { return _isDetailsVisible; }
            set { SetProperty(ref _isDetailsVisible, value); }
        }


        private ObservableCollection<AvailableRoomRequest> _rooms;

        public ObservableCollection<AvailableRoomRequest> Rooms
        {
            get { return _rooms; }
            set
            {
                SetProperty(ref _rooms, value);

            }
        }

        private AvailableRoomRequest _selectedRoom;

        public AvailableRoomRequest SelectedRoom
        {
            get { return _selectedRoom; }
            set { SetProperty(ref _selectedRoom, value); }
        }

        private ObservableCollection<StayType> _stayTypes;

        public ObservableCollection<StayType> StayTypes
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

        private int _roomId;

        public int RoomId
        {
            get { return _roomId; }
            set { SetProperty(ref _roomId, value); }
        }

        private DateTime _startDate;

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                SetProperty(ref _startDate, value);
                OnSearchParametersChange();
            }
        }

        private DateTime _endDate;

        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }

            set
            {
                SetProperty(ref _endDate, value);
                OnSearchParametersChange();
            }
        }
        public DelegateCommand CloseCommand { get; }
        public DelegateCommand NextCommand { get; }
        #endregion
        #region Events Region

        private void CreateNewReservationDialogViewModel_OnDateChanged()
        {
            if (Rooms != null)
            {
                if (Rooms.Any())
                    Rooms.Clear();
            }

            var rooms = _roomService.LoadAvailableRooms(StartDate, EndDate, PeopleNumber);
            if (rooms != null)
            {
                Rooms = new ObservableCollection<AvailableRoomRequest>(rooms);
            }

            if (rooms is null)
            {
                MessageBox.Show("Nema slobodnih soba za izabrani period", "Obavestenje");
            }


        }

        private void OnSearchParametersChange()
        {
            DateChanged?.Invoke();
        }

        private void OnInitialize()
        {
            Initialize?.Invoke();
        }

        #endregion
        #region Constructor

        private readonly IRoomService _roomService;
        private readonly IStayTypeService _stayTypeService;
        public CreateNewReservationDialogViewModel(IRoomService roomService, IStayTypeService stayTypeService)
        {
            _roomService = roomService;
            _stayTypeService = stayTypeService;
            NextCommand = new DelegateCommand(NextCommandExecute);
            CloseCommand = new DelegateCommand(OnCloseCommand);

        }



        #endregion
        #region Commands
        private void OnCloseCommand()
        {
            //RequestClose?.Invoke();
                //Obavesti da je zatvoren dialog dugmetom
                 //Odnosno da je zatvoren uspesno upisanom rezervacijom
        }
        private void NextCommandExecute()
        {
            IsRoomSelected = Rooms != null && Rooms.Any();
            IsStayTypeSelected = StayTypes != null && StayTypes.Any();
            IsPeopleNumberValid = PeopleNumber > 0;
            IsDetailsVisible = IsStayTypeSelected
                               && IsRoomSelected
                               && IsPeopleNumberValid;
        }



        #endregion

        
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            DateChanged -= CreateNewReservationDialogViewModel_OnDateChanged;
            Initialize -= CreateNewReservationDialogViewModel_Initialize;
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            StartDate = parameters.GetValue<DateTime>("dolazak");
            EndDate = StartDate.Date.AddDays(2);
            DateChanged += CreateNewReservationDialogViewModel_OnDateChanged;
            Initialize += CreateNewReservationDialogViewModel_Initialize;
            OnInitialize();
        }

        private void CreateNewReservationDialogViewModel_Initialize()
        {
            try
            {
                var types = _stayTypeService.GetAllTypes();
                StayTypes = new ObservableCollection<StayType>(types);
            }
            catch (StayTypesNotFoundException)
            {
                MessageBox.Show("Tipovi smestaja nisu pronadjeni. " +
                                "Da li ste upisali u bazu, tipove smestaja koje vas objekat nudi?");
            }
        }



        public string Title => "Upisi rezervaciju";
        public event Action<IDialogResult> RequestClose;
    }
}

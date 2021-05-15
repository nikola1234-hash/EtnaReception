using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using BookSoft.BLL.Services;
using BookSoft.Domain.Models;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Reception.Dialogs
{
    public delegate void DateChange();
    public class CreateNewReservationDialogViewModel : BindableBase, IDialogAware
    {
        public event DateChange DateChanged;
        private bool _isVisible;


        private void OnSearchParametersChange()
        {
            DateChanged?.Invoke();
        }

        public bool IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value); }
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

        public int  RoomId
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

        private readonly IRoomService _roomService;
        public CreateNewReservationDialogViewModel(IReceptionService receptionService, IReservationService reservationService, IRoomService roomService)
        {
            _roomService = roomService;


        }

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

            IsVisible = Rooms.Any(s => s != null);
                
            if (rooms is null)
            {
                MessageBox.Show("Nema slobodnih soba za izabrani period", "Obavestenje");
            }

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

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            StartDate = parameters.GetValue<DateTime>("dolazak");
            EndDate = StartDate.Date.AddDays(2);
            DateChanged += CreateNewReservationDialogViewModel_OnDateChanged;
        }

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


        public string Title => "Upisi rezervaciju";
        public event Action<IDialogResult> RequestClose;
    }
}

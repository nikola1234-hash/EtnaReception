using Booking.Events;
using Booking.Mediator;
using Booking.Wrapper;
using BookSoft.BLL;
using BookSoft.DAL;
using BookSoft.Domain.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Booking.ViewModels
{
    public class BookingViewModel : BindableBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IEventAggregator _eventAggregator;
        private readonly IBookingCalculate _calculationService;

        private ObservableCollection<AvailableRoomRequest> _rooms;
        private AvailableRoomRequest _selectedRoom;
        private IEnumerable<StayType> _stayTypes;
        private StayType _selectedStayType;
        private ObservableCollection<Guest> _guests;
        private int _selectedGuest;
        private SearchWrapper _searchRooms;

        public BookingViewModel(IUnitOfWork unit, IEventAggregator eventAggregator,
                                IBookingCalculate calculationService)
        {
            _unit = unit;
            _calculationService = calculationService;
            SearchRooms = new SearchWrapper();
            SearchRooms.StateChanged += SearchRooms_StateChanged;
            _eventAggregator = eventAggregator;
            SearchCommand = new DelegateCommand(SearchExecute, CanSearchExecute).ObservesCanExecute(() => SearchRooms.IsEnabled);
            _eventAggregator.GetEvent<LoadEvent>().Subscribe(OnLoadEvent);
            Calculation.GetInstance().StayTypeChanged += BookingViewModel_StayTypeChanged;
            SelectedRoomChange.GetInstance().RoomSelectionChanged += BookingViewModel_RoomSelectionChanged;
        }

        private void BookingViewModel_RoomSelectionChanged(object sender, RoomSelectionChangeEventArgs e)
        {
            DetailsVisibility = Price > 0 && Days > 0
                                   && TotalPrice > 0
                                   && _selectedStayType != null
                                   && _selectedRoom != null;
        }

        private void SearchRooms_StateChanged()
        {
            PopulateDetailsPreview();
        }

        // Booking Details preview area.
        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }
        private int _days;
        public int Days
        {
            get { return _days; }
            set { SetProperty(ref _days, value); }
        }
        private decimal _totalPrice;
        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set { SetProperty(ref _totalPrice, value); }
        }

        private void BookingViewModel_StayTypeChanged(object sender, TypeChangedEventArgs e)
        {
            PopulateDetailsPreview();
        }
        private void PopulateDetailsPreview()
        {
            if(_selectedStayType != null)
            {
                decimal price = _selectedStayType.Price;
                Price = price;
                int days = _calculationService.CalculateDays(SearchRooms.StartDate, SearchRooms.EndDate);
                Days = days;
                TotalPrice = _calculationService.CalculatePrice(days, SearchRooms.NumberOfPeople, price);
               
            }
         
        }
        private bool CanSearchExecute()
        {
            return SearchRooms.IsEnabled;
        }

        private bool _detailsVisibility;
        public bool DetailsVisibility
        {
            get { return _detailsVisibility; }
            set 
            {
                SetProperty(ref _detailsVisibility, value);
            }
        }
        private bool _guestListVisibility;
        public bool GuestListVisibility
        {
            get { return _guestListVisibility; }
            set { SetProperty(ref _guestListVisibility, value); }
        }
        private void OnLoadEvent()
        {

            StayTypes= _unit.StayType.GetAll();
        }

        private void SearchExecute()
        {
            var rooms = _unit.Room
                 .GetAvailableRoomsForDates(SearchRooms.StartDate, SearchRooms.EndDate, SearchRooms.NumberOfPeople);
            Rooms = new ObservableCollection<AvailableRoomRequest>(rooms);
            
        }

        public bool CanExecute
        {
            get { return SearchRooms.HasErrors == false; }
            set
            {
                CanExecute = value;
                RaisePropertyChanged(nameof(CanExecute));
            }
        }


        public SearchWrapper SearchRooms
        {
            get => _searchRooms;
            set => SetProperty(ref _searchRooms, value);
        }




        public int SelectedGuest
        {
            get { return _selectedGuest; }
            set
            {
                SetProperty(ref _selectedGuest, value);
            }
        }
        public ObservableCollection<Guest> Guests
        {
            get { return _guests; }
            set
            {
                SetProperty(ref _guests, value);
            }
        }
        public StayType SelectedStayType
        {
            get { return _selectedStayType; }
            set
            {
                SetProperty(ref _selectedStayType, value);
                if(_selectedStayType != null)
                {
                    Calculation.GetInstance().OnStayTypeChanged(this, _selectedStayType);
                }
            }
        }
        public IEnumerable<StayType> StayTypes
        {
            get { return _stayTypes; }
            set
            {
                SetProperty(ref _stayTypes, value);
            }
        }
        public AvailableRoomRequest SelectedRoom
        {
            get { return _selectedRoom; }
            set 
            { 
                SetProperty(ref _selectedRoom, value);
                SelectedRoomChange.GetInstance().OnRoomSelectionChanged(this, _selectedRoom);
            }
        }
        public ObservableCollection<AvailableRoomRequest> Rooms
        {
            get { return _rooms; }
            set 
            { 
                SetProperty(ref _rooms, value);
            }
        }


        public ICommand SearchCommand { get; }
        
    }
}

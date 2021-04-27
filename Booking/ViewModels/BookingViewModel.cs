using Booking.Events;
using Booking.Mediator;
using Booking.Services.Facade;
using Booking.Wrapper;
using BookSoft.BLL;
using BookSoft.BLL.Navigation;
using BookSoft.BLL.Regions;
using BookSoft.BLL.Services;
using BookSoft.DAL;
using BookSoft.Domain.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace Booking.ViewModels
{
    public class BookingViewModel : BindableBase, INavigationAware, IDisposable
    {
        private readonly IUnitOfWork _unit;
        private readonly IEventAggregator _eventAggregator;
        private readonly IBookingCalculate _calculationService;
        private readonly ISearchGuestService _searchGuestService;
        private readonly IBookingFacade _bookingFacade;
        private readonly IRegionManager _regionManager;

        private ObservableCollection<AvailableRoomRequest> _rooms;
        private AvailableRoomRequest _selectedRoom;
        private IEnumerable<StayType> _stayTypes;
        private StayType _selectedStayType;
        private ObservableCollection<Guest> _guests;
        private int _selectedGuest;
        private SearchWrapper _searchRooms;

        public BookingViewModel(IUnitOfWork unit, IEventAggregator eventAggregator,
                                IBookingCalculate calculationService,
                                ISearchGuestService searchGuestService,
                                IBookingFacade bookingFacade,
                                IRegionManager regionManager)
        {
            _unit = unit;
            _calculationService = calculationService;
            _searchGuestService = searchGuestService;
            _bookingFacade = bookingFacade;
            _eventAggregator = eventAggregator;

            _regionManager = regionManager;

            GuestResults = new ObservableCollection<Guest>();
            SearchRooms = new SearchWrapper();
            Guest = new GuestWrapper();

            SearchCommand = new DelegateCommand(SearchExecute, CanSearchExecute).ObservesCanExecute(() => SearchRooms.IsEnabled);
            BookCommand = new DelegateCommand<object>(BookExecute, CanBookExecute).ObservesCanExecute(()=> IsGuestFormValid);

            _eventAggregator.GetEvent<LoadEvent>().Subscribe(OnLoadEvent);

            Calculation.GetInstance().StayTypeChanged += BookingViewModel_StayTypeChanged;
            SelectedRoomChange.GetInstance().RoomSelectionChanged += BookingViewModel_RoomSelectionChanged;
            SelectedGuestEvent.GetInstance().SelectedGuestChanged += OnSelectedGuestChange;

            SearchRooms.StateChanged += SearchRooms_StateChanged;
            Guest.StateChanged += Guest_StateChanged;

        }

        private void OnSelectedGuestChange(object sender, SelectedGuestEventArgs e)
        {
            //TODO: Refactor
            if(e.Guest != null)
            {
                Guest = new GuestWrapper
                {
                    FirstName = e.Guest.FirstName,
                    LastName = e.Guest.LastName,
                    Address = e.Guest.Address,
                    Email = e.Guest.Email,
                    Phone = e.Guest.Phone,
                    Jmbg = e.Guest.Jmbg
                };
            }
            return;
        }

        private void Guest_StateChanged()
        {
            
           if(GuestResults.Count() > 0)
           {
               GuestResults.Clear();
           }
           var guests = _searchGuestService.SearchGuest(Guest.FirstName, Guest.LastName, Guest.Phone);
           GuestListVisibility = guests.Any();
           if (guests.Any())
           {
               GuestResults = new ObservableCollection<Guest>(guests);
           }
           IsGuestFormValid = Guest.HasErrors == false 
                           || _selectedGuestResult != null;

        }

        private bool _isGuestFormValid;
        public bool IsGuestFormValid
        {
            get { return _isGuestFormValid; }
            set 
            {
                SetProperty(ref _isGuestFormValid, value); 
            }
        }

        private bool CanBookExecute(object arg)
        {
            return IsGuestFormValid;
        }

        private void BookExecute(object richTextBox)
        {
            IsGuestSelected = _selectedGuestResult != null;
            bool isSuccess = false;
            if (richTextBox != null)
            {
                RichTextBox textBox = richTextBox as RichTextBox;
                TextRange textRange = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
                Guest.Details = textRange.Text;
            }
            if(_selectedGuestResult is null)
            {
                _selectedGuestResult = new Guest();
            }
            isSuccess = _bookingFacade.CreateBooking(this);
            if (isSuccess)
            {
                var result = MessageBox.Show("Uspesno izvrsena rezervacija", "Uspesno", MessageBoxButton.OK);
                if(result == MessageBoxResult.OK)
                {
                    _regionManager.RequestNavigate(RegionNames.MainRegion, NavigationType.BookingView.ToString());
                }
            }
           


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
                int days = _calculationService.CalculateDays(SearchRooms.StartDate, SearchRooms.EndDate);
                decimal totalPrice = _calculationService.CalculatePrice(days, SearchRooms.NumberOfPeople, price);
                Price = price;
                Days = days;
                TotalPrice = totalPrice;
               
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

           
        }

        private void SearchExecute()
        {
            var rooms = _unit.Room
                 .GetAvailableRoomsForDates(SearchRooms.StartDate, SearchRooms.EndDate, SearchRooms.NumberOfPeople);
            Rooms = new ObservableCollection<AvailableRoomRequest>(rooms);
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            StayTypes = _unit.StayType.GetAll();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Guest.StateChanged -= Guest_StateChanged;
            Calculation.GetInstance().StayTypeChanged -= BookingViewModel_StayTypeChanged;
            SelectedRoomChange.GetInstance().RoomSelectionChanged -= BookingViewModel_RoomSelectionChanged;
            SearchRooms.StateChanged -= SearchRooms_StateChanged;
            SelectedGuestEvent.GetInstance().SelectedGuestChanged -= OnSelectedGuestChange;
           
        }

        public void Dispose()
        {
            throw new NotImplementedException();
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
        private GuestWrapper _guest;
        public GuestWrapper Guest
        {
            get { return _guest; }
            set 
            { 
                SetProperty(ref _guest, value);
            }
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

        private ObservableCollection<Guest> _guestResults;
        public ObservableCollection<Guest> GuestResults
        {
            get { return _guestResults; }
            set { SetProperty(ref _guestResults, value); }
        }
        private Guest _selectedGuestResult;
        public Guest SelectedGuestResult
        {
            get { return _selectedGuestResult; }
            set
            {
                SetProperty(ref _selectedGuestResult, value);
                SelectedGuestEvent.GetInstance().OnSelectedGuestChange(this, _selectedGuestResult);
            }
        }
        private bool _isGuestSelected;
        public bool IsGuestSelected
        {
            get { return _isGuestSelected; }
            set { SetProperty(ref _isGuestSelected, value); }
        }
        public ICommand SearchCommand { get; }
        public DelegateCommand<object> BookCommand { get; }
     
    }
}

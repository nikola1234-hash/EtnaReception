using Booking.Events;
using Booking.Mediator;
using Booking.Model;
using Booking.Wrapper;
using BookSoft.DAL;
using BookSoft.Domain.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Booking.ViewModels
{
    public class BookingViewModel : BindableBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IEventAggregator _eventAggregator;

        private ObservableCollection<AvailableRoomRequest> _rooms;
        private AvailableRoomRequest _selectedRoom;
        private IEnumerable<StayType> _stayTypes;
        private StayType _selectedStayType;
        private ObservableCollection<Guest> _guests;
        private int _selectedGuest;
        private SearchWrapper _searchRooms;

        public BookingViewModel(IUnitOfWork unit, IEventAggregator eventAggregator)
        {
            _unit = unit;
            SearchRooms = new SearchWrapper();
            _eventAggregator = eventAggregator;
            SearchCommand = new DelegateCommand(SearchExecute, CanSearchExecute).ObservesCanExecute(() => SearchRooms.IsEnabled);
            _eventAggregator.GetEvent<LoadEvent>().Subscribe(OnLoadEvent);
            Calculation.GetInstance().StayTypeChanged += BookingViewModel_StayTypeChanged;
        }

        private void BookingViewModel_StayTypeChanged(object sender, TypeChangedEventArgs e)
        {
            
        }

        private bool CanSearchExecute()
        {
            return SearchRooms.IsEnabled;
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
                    Calculation.GetInstance().OnStayTypeChanged(this, SelectedStayType);
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

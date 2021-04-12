using Booking.Events;
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

        private ObservableCollection<Room> _rooms;
        private int _selectedRoom;
        private ObservableCollection<StayType> _stayTypes;
        private int _selectedStayType;
        private ObservableCollection<Guest> _guests;
        private int _selectedGuest;
        private SearchWrapper _searchRooms;
        public BookingViewModel(IUnitOfWork unit, IEventAggregator eventAggregator)
        {
            _unit = unit;
            _eventAggregator = eventAggregator;
            SearchCommand = new DelegateCommand(SearchExecute).ObservesProperty(() => AnyErrors);
            _eventAggregator.GetEvent<LoadEvent>().Subscribe(OnLoadEvent);
        }
        private DateTime _testDate;

        public DateTime TestDate
        {
            get { return _testDate; }
            set 
            {
                SetProperty(ref _testDate, value);
            }
        }

        private void OnLoadEvent()
        {
            SearchRooms = new SearchWrapper();
            //StayTypes Load
            
        }

        private void SearchExecute()
        {
            var rooms = _unit.Room.GetAvailableRoomsForDates(SearchRooms.StartDate, SearchRooms.EndDate, SearchRooms.NumberOfPeople);
            Rooms = new ObservableCollection<Room>((List<Room>)rooms);
            
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
                _selectedGuest = value;
                SetProperty(ref _selectedGuest, value);
            }
        }
        public ObservableCollection<Guest> Guests
        {
            get { return _guests; }
            set
            {
                _guests = value;
                SetProperty(ref _guests, value);
            }
        }
        public int SelectedStayType
        {
            get { return _selectedStayType; }
            set
            {
                _selectedStayType = value;
                SetProperty(ref _selectedStayType, value);
            }
        }
        public ObservableCollection<StayType> StayTypes
        {
            get { return _stayTypes; }
            set
            {
                _stayTypes = value;
                SetProperty(ref _stayTypes, value);
            }
        }
        public int SelectedRoom
        {
            get { return _selectedRoom; }
            set 
            { 
                _selectedRoom = value;
                SetProperty(ref _selectedRoom, value);
            }
        }
        public ObservableCollection<Room> Rooms
        {
            get { return _rooms; }
            set 
            { 
                _rooms = value;
                SetProperty(ref _rooms, value);
            }
        }
        private bool _anyErrors;

        public bool AnyErrors
        {
            get => SearchRooms.HasErrors;
            set 
            {
                _anyErrors = value;
                SetProperty(ref _anyErrors, value);
            }
        }
        public ICommand SearchCommand { get; }


    }
}

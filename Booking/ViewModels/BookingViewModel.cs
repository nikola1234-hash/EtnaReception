using Booking.Model;
using BookSoft.Domain.Models;
using Prism.Mvvm;
using System.Collections.Generic;

namespace Booking.ViewModels
{
    public class BookingViewModel : BindableBase
    {
        private IEnumerable<Room> _rooms;
        private int _selectedRoom;
        private IEnumerable<StayType> _stayTypes;
        private int _selectedStayType;
        private IEnumerable<Guest> _guests;
        private int _selectedGuest;







        public int SelectedGuest
        {
            get { return _selectedGuest; }
            set
            {
                _selectedGuest = value;
                SetProperty(ref _selectedGuest, value);
            }
        }
        public IEnumerable<Guest> Guests
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
        public IEnumerable<StayType> StayTypes
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
        public IEnumerable<Room> Rooms
        {
            get { return _rooms; }
            set 
            { 
                _rooms = value;
                SetProperty(ref _rooms, value);
            }
        }




    }
}

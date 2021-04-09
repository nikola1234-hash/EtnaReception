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

using BookSoft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Events
{
    public class RoomSelectionChangeEventArgs : EventArgs
    {
        public AvailableRoomRequest RoomRequest { get; set; }

    }
}

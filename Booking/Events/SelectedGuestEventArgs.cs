using BookSoft.Domain.Models;
using System;

namespace Booking.Events
{
    public class SelectedGuestEventArgs : EventArgs
    {
        public Guest Guest { get; set; }
    }
}

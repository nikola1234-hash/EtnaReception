using BookSoft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Events
{
    public class TypeChangedEventArgs : EventArgs
    {
        public StayType StayType { get; set; }
    }
}

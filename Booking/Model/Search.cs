using System;

namespace Booking.Model
{
    public class Search
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfPeople { get; set; }
        public int SelectedType { get; set; }
    }
}

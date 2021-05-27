using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Domain.Models
{
    public class RoomReservation : DomainObject
    {
        public int ReservationId { get; set; }
        public int RoomId { get; set; }
        public int StayTypeId { get; set; }
        public int Persons { get; set; }
    }
}

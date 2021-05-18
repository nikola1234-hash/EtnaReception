using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Domain.Models
{
    public class RoomScheduler : Guest
    {
        public string RoomNumber { get; set; }
        public int ReservationId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Persons { get; set; }
        public string Title { get; set; }
        public int StayTypeId { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? DiscountPercent { get; set; }
    }
}

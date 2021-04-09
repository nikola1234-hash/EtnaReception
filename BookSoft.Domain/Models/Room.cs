namespace BookSoft.Domain.Models
{
    public class Room : DomainObject
    {
        public string RoomNumber { get; set; }
        public int CapacityId { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
    }
}

namespace BookSoft.Domain.Models
{
    public class AvailableRoomRequest : DomainObject
    {
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }
    }
}

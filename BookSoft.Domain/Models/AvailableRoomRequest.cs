namespace BookSoft.Domain.Models
{
    public class AvailableRoomRequest
    {
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }
    }
}

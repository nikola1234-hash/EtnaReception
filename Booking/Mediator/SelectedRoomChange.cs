using Booking.Events;
using BookSoft.Domain.Models;
using System;

namespace Booking.Mediator
{
    public sealed class SelectedRoomChange
    {
        private static readonly SelectedRoomChange _instance = new SelectedRoomChange();

        public SelectedRoomChange()
        {

        }

        public static SelectedRoomChange GetInstance()
        {
            return _instance;
        }
        public event EventHandler<RoomSelectionChangeEventArgs> RoomSelectionChanged;

        public void OnRoomSelectionChanged(object sender, AvailableRoomRequest roomRequest)
        {
            var selectedRoomDelegate = RoomSelectionChanged as EventHandler<RoomSelectionChangeEventArgs>;
            if (selectedRoomDelegate != null)
            {
                selectedRoomDelegate(sender, new RoomSelectionChangeEventArgs { RoomRequest = roomRequest });
            }
        }


    }
}

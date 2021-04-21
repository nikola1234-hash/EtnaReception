using Booking.Events;
using BookSoft.Domain.Models;
using System;

namespace Booking.Mediator
{
    public sealed class SelectedGuestEvent
    {
        private static SelectedGuestEvent _instance = new SelectedGuestEvent();

        private SelectedGuestEvent() { }

        public static SelectedGuestEvent GetInstance()
        {
            return _instance;
        }
        public event EventHandler<SelectedGuestEventArgs> SelectedGuestChanged;

        public void OnSelectedGuestChange(object sender, Guest guest)
        {
            var selectedGuestDelegate = SelectedGuestChanged as EventHandler<SelectedGuestEventArgs>;
            if(selectedGuestDelegate != null)
            {
                selectedGuestDelegate(this, new SelectedGuestEventArgs { Guest = guest });
            }
        }
    }
}

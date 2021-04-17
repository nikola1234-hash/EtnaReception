using Booking.Events;
using BookSoft.Domain.Models;
using System;

namespace Booking.Mediator
{
    public sealed class Calculation
    {
        private static readonly Calculation _instance = new Calculation();
        private Calculation()
        {

        }

        public static Calculation GetInstance()
        {
            return _instance;
        }
        public event EventHandler<TypeChangedEventArgs> StayTypeChanged;
        public void OnStayTypeChanged(object sender, StayType type)
        {
            var stayTypeChangeDelegate = StayTypeChanged as EventHandler<TypeChangedEventArgs>;
            if(stayTypeChangeDelegate != null)
            {
                stayTypeChangeDelegate(sender, new TypeChangedEventArgs { StayType = type });
            }
        }
    }
}

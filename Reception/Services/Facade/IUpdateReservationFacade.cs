using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.BLL.Services;

namespace Reception.Services.Facade
{
    public interface IUpdateReservationFacade
    {
        public UpdateStatus UpdateReservation(DateTime startDate, DateTime endDate, int reservationId, int statusId, int roomId ,int stayTypeId, int persons);
    }
}

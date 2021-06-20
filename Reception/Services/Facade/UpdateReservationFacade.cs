using System;
using BookSoft.BLL.Services;

namespace Reception.Services.Facade
{
    public class UpdateReservationFacade : IUpdateReservationFacade
    {

        private readonly IEditScheduleService _editScheduleService;

        public UpdateReservationFacade(IEditScheduleService editScheduleService)
        {
            _editScheduleService = editScheduleService;
        }


        public UpdateStatus UpdateReservation(DateTime startDate, DateTime endDate, int reservationId, int statusId, int roomId, int stayTypeId, int persons)
        {
            
            var dates = _editScheduleService.UpdateReservationDates(startDate, endDate, reservationId);
            var status = _editScheduleService.UpdateReservationStatus(reservationId, statusId);
            var details  = _editScheduleService.UpdateRoomReservationDetails(reservationId, roomId, stayTypeId, persons);
            bool done = dates == UpdateStatus.Done && status == UpdateStatus.Done && details == UpdateStatus.Done;
            if (done)
            {
                return UpdateStatus.Done;
            }
            return UpdateStatus.Error;
        }
    }

}

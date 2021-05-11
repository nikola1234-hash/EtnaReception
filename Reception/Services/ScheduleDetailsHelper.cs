using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Domain.Models;

namespace Reception.Services
{
    public sealed class ScheduleDetailsHelper
    {
        public static string FormatSubject(RoomScheduler room)
        {
            return $"Tip smestaja: {room.Title}, broj osoba: {room.Persons}";
        }
        public static string FormatDetails(RoomScheduler room)
        {
            return $"Detalji gosta: {room.FirstName} {room.LastName}," +
                   $"Telefon: {room.Phone}, Adresa: {room.Address}";
        }
    }
}

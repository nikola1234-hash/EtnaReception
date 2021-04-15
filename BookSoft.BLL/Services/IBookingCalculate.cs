using System;

namespace BookSoft.BLL

{
    public interface IBookingCalculate
    {
        public int CalculateDays(DateTime startDate, DateTime endDate);
        public decimal CalculatePrice(int days, int numberOfPeople, decimal price);
    }
}

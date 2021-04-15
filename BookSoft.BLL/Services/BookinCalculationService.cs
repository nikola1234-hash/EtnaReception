using System;

namespace BookSoft.BLL.Services
{
    public class BookinCalculationService : IBookingCalculate
    {
        public int CalculateDays(DateTime startDate, DateTime endDate)
        {
            int days = endDate.Date.Subtract(startDate.Date).Days;
            return days;
        }
        public decimal CalculatePrice(int days, int numberOfPeople, decimal price)
        {
            var output = (days * numberOfPeople) * price;
            return output;
        }
    }
}

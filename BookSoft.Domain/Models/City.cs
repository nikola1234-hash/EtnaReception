namespace BookSoft.Domain.Models
{
    public class City : DomainObject
    {
        public string CityName { get; set; }
        public int CountryId { get; set; }

    }
}

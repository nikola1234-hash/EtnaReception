namespace BookSoft.Domain.Models
{
    public class Company : DomainObject
    {
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public int CityId { get; set; }
        public string CompanyAddress { get; set; }
        public string Details { get; set; }
    }
}

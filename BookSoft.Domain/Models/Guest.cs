namespace BookSoft.Domain.Models
{
    public class Guest : DomainObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Details { get; set; }
        public string Jmbg { get; set; }

    }
}

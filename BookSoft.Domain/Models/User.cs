using System;

namespace BookSoft.Domain.Models
{
    public class User : DomainObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int CompanyId { get; set; }
    }
}

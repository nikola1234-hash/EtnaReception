using BookSoft.Domain;
using BookSoft.Domain.Models;
using System.Linq;

namespace BookSoft.DAL.Repositories
{
    public class UserRepository
    {
        private readonly IDataService _dataService;

        public UserRepository(IDataService dataService)
        {
            _dataService = dataService;
        }

        public User GetByUsername(string username)
        {
            var user = _dataService.LoadData<User, dynamic>("spUser_GetByUsername", new { username });
            return user.FirstOrDefault();
        }
        public int RegisterUser(object user)
        {
            var rows =_dataService.SaveData<dynamic>("spUser_InsertUser", user);
            return rows;
        }
        public User SetActiveStatus(int id, bool isActive)
        {
            var user = _dataService.LoadData<User, dynamic>("spUser_SetActiveStatus", new { id, isActive });
            return user.FirstOrDefault();
        }
    }
}

using BookSoft.Domain;
using BookSoft.Domain.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BookSoft.DAL.Repositories
{
    public class CompanyRepository
    {
        private readonly IDataService _dataService;

        public CompanyRepository(IDataService dataService)
        {
            _dataService = dataService;
        }

        public Company GetCompanyById(int id)
        {
            var output = _dataService.LoadData<Company, dynamic>("spCompany_GetCompany", new { Id = id });
            return output.FirstOrDefault();
        }
        public IEnumerable<Company> GetAllCompanies()
        {
            var output = _dataService.LoadData<Company, dynamic>("spCompany_GetAll", new { });
            return output;
        }
        public int CreateCompany(int cityId, string companyName, string email, string companyAddress, string details)
        {
            var company = new
            {
                companyName,
                email,
                companyAddress,
                details,
                cityId
            };
            int rows = _dataService.SaveData<dynamic>("spCompany_Insert", company);
            return rows;
        }
        public Company GetActiveCompany()
        {
            var output = _dataService.LoadData<Company, dynamic>("spCompany_GetActiveCompany", new { });
            return output.FirstOrDefault();
        }
        public Company SetCompanyAsInactive(int id)
        {
            var company = _dataService.LoadData<Company, dynamic>("spCompany_SetInactive", new { id });
            return company.FirstOrDefault();
        }
    }
}

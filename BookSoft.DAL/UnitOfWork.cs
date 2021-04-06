using BookSoft.DAL.Repositories;
using BookSoft.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataService _dataService;

        public UnitOfWork(IDataService dataService)
        {
            _dataService = dataService;
            User = new UserRepository(_dataService);
            Company = new CompanyRepository(_dataService);
        }

        public UserRepository User { get; }
        public CompanyRepository Company { get; }
    }
}

﻿using Domain.Repositories;
using Repository.Implementation;
using System;

namespace Persistance.Implementation
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IEmployeeRepository> _lazyEmployeeRepository;
   

        public RepositoryManager(ApplicationDbContext dbContext)
        {
            _lazyEmployeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(dbContext));
           
        }

        public IEmployeeRepository EmployeeRepository => _lazyEmployeeRepository.Value;

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();
    }
}

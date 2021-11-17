using Domain.Repositories;
using Repository.Implementation;
using System;

namespace Persistance.Implementation
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IEmployeeRepository> _lazyEmployeeRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;


        public RepositoryManager(ApplicationDbContext dbContext)
        {
            _lazyEmployeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(dbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));

        }

        public IEmployeeRepository EmployeeRepository => _lazyEmployeeRepository.Value;

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}

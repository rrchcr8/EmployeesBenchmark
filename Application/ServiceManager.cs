
using Domain.Repositories;
using Services;
using Services.Abstractions;
using System;

namespace Application.ServiceManager
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IEmployeeService> lazyEmployeeService;
        

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            this.lazyEmployeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager));
        }

        public IEmployeeService EmployeeService => this.lazyEmployeeService.Value;

    }
}

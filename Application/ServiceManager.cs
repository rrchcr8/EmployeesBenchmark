
using Domain.Repositories;
using Repository;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

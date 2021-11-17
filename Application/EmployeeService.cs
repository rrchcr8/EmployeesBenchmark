using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using ServiceDomain.Abstractions;

namespace Application.Implementations
{
    class EmployeeService : IEmployeeService
    {
        private readonly IDB;

        public CampaignService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }


        public Task<Employee> CreateEmployeeAsync(Employee Employee)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> DeleteEmployeeAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetEmployeesAsync(Guid workspaceId)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployeeAsync(Guid id, Employee Employee)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Contracts;
using Domain;
using Domain.Repositories;
using Services.Abstractions;
using System.Threading;

namespace Services
{
    class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager repositoryManager ;

        public EmployeeService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await repositoryManager.EmployeeRepository.GetEmployeesAsync();
            
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await repositoryManager.EmployeeRepository.GetByIdAsync(id);
        }

        public async Task<Employee> CreateEmployeeAsync(EmployeeForCreationDto employeeForCreation)
        {
            var employee = employeeForCreation.Adapt<Employee>();
            employee.EmployeeCode = Guid.NewGuid().ToString();
            repositoryManager.EmployeeRepository.Insert(employee);
            await repositoryManager.UnitOfWork.SaveChangesAsync();
            return employee;
        }

        public async Task UpdateEmployeeAsync(int id, EmployeeForUpdateDto employeeForUpdate)
        {
            Employee employee = await repositoryManager.EmployeeRepository.GetByIdAsync(id);
            if (employee != null) {
                employee.Name = employeeForUpdate.Name;
                employee.ImageUrl = employeeForUpdate.ImageUrl;
                employee.JobTitle = employeeForUpdate.JobTitle;
                employee.Phone = employeeForUpdate.Phone;
                employee.Email = employeeForUpdate.Email;
                await repositoryManager.UnitOfWork.SaveChangesAsync();
            }
            
        }

        public async Task DeleteEmployeeAsync(int id, CancellationToken cancellationToken = default)
        {
          var employee = await repositoryManager.EmployeeRepository.GetByIdAsync(id);
            if (employee != null)
            {
                repositoryManager.EmployeeRepository.Remove(employee);
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            }
            }
    }
}

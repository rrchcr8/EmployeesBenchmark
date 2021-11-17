using Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceDomain.Abstractions
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(Guid id);
        Task<Employee> CreateEmployeeAsync(EmployeeForCreationDTO employeeForCreation);
        public Task<Employee> UpdateEmployeeAsync(Guid id, Employee Employee);
        public Task<Employee> DeleteEmployeeAsync(Guid id);
        
        ;

    }
}

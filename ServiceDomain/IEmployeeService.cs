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
        Task<Employee> CreateEmployeeAsync(EmployeeForCreationDto employeeForCreation);
        public Task UpdateEmployeeAsync(Guid id, EmployeeForUpdateDto Employee);
        public Task DeleteEmployeeAsync(Guid id);
    }
}

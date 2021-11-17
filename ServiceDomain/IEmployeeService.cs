using Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> CreateEmployeeAsync(EmployeeForCreationDto employeeForCreation);
        public Task UpdateEmployeeAsync(int id, EmployeeForUpdateDto Employee);
        public Task DeleteEmployeeAsync(int id);
    }
}

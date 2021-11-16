using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceDomain.Abstractions
{
    interface IEmployeService
    {
        
   public Task<Employee> UpdateEmployeeAsync(Guid id, Employee Employee);
    public Task<Employee> DeleteEmployeeAsync(Guid id);
    public Task<Employee> CreateEmployeeAsync(Employee Employee);
    public Task<Employee> GetEmployeeByIdAsync(Guid id);
    public Task<IEnumerable<Employee>> GetEmployeesAsync(Guid workspaceId);
}
}

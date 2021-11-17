using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IEmployeeRepository
    {
        void Insert(Employee Employee);
        
        void Remove(Employee employee);
        public Task<Employee> GetByIdAsync(int id);
        public Task<IEnumerable<Employee>> GetEmployeesAsync();

    }
}

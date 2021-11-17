using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IEmployeeRepository
    {
        void Insert(Employee Employee);
        public Task<Employee> UpdateAsync(Guid id, Employee Employee);
        void Remove(Guid id);
        public Task<Employee> GetByIdAsync(Guid id);
        public Task<IEnumerable<Employee>> GetEmployeesAsync();
    }
}

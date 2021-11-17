using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    class EmployeeRepository:IEmployeeRepository
    {
        private readonly IApplicationDbContext applicationDbContext;

        public EmployeeRepository(IApplicationDbContext applicationDbContext) {
            this.applicationDbContext = applicationDbContext;
        }


        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await applicationDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int EmployeeId) =>
            await applicationDbContext.Employees.FirstOrDefaultAsync(x => x.Id == EmployeeId);

       
       

        public void Insert(Employee Employee) => applicationDbContext.Employees.Add(Employee);

        public void Remove(Employee Employee) => applicationDbContext.Employees.Remove(Employee);

      

    }
}

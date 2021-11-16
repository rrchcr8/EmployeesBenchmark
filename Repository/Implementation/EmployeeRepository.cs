using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    class EmployeeRepository
    {
        private readonly IApplicationDbContext applicationDbContext;

        public EmployeeRepository(IApplicationDbContext applicationDbContext) {
            this.applicationDbContext = applicationDbContext;
        }

        public void Create(Employee employee)
        {
            this.applicationDbContext.Employees.Add(employee);
        }


    }
}

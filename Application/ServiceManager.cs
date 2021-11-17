using Repository;
using ServiceDomain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceManager
{
    public class ServiceManager : IServiceManager
    {
        private readonly IApplicationDbContext applicationDbContext;
        public ServiceManager(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

                
        public IEmployeeService EmployeeService {

            get
            {
                return new EmployeeService(this.applicationDbContext);
            }
        }
    }
}

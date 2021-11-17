using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IApplicationDbContext
    {
        DbSet<Employee> Employees { get; set; }

    
    }
}

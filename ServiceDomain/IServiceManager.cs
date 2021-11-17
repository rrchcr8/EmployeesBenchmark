using Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceDomain.Abstractions
{
    public interface IServiceManager
    {
        IEmployeeService EmployeeService { get; }

    }
}

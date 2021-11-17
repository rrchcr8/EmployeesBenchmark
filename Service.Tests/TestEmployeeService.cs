using Domain;
using Domain.Repositories;
using Moq;
using Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Service.Tests
{
    public class TestEmployeeService
    {
        public Mock<IRepositoryManager> repositoryManagerMock;
        public EmployeeService employeeService;

        public TestEmployeeService()
        {
            repositoryManagerMock = new Mock<IRepositoryManager>();
            employeeService = new EmployeeService(repositoryManagerMock.Object);
        }

        [Fact]
        public async Task GetEmployees()
        {

            repositoryManagerMock
                .Setup(repository => repository.EmployeeRepository.GetEmployeesAsync())
                .ReturnsAsync(GetEMployeesTestList());

            IEnumerable<Employee> result = await employeeService.GetAllEmployeesAsync();

            Assert.Single(result);
        }

        private List<Employee> GetEMployeesTestList()
        {

            return new List<Employee>()
            {
                new Employee
                {
                    Id =  new int(),
                    Name="test name",
                    Email="sadasdasds",
                    JobTitle="tester",
                    Phone="1212122",
                    ImageUrl="url test",
                    EmployeeCode= Guid.NewGuid().ToString()
        }
            };
        }


    }
}

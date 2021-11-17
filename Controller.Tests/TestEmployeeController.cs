using Contracts;
using Domain;
using EmployeesBenchmark.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services;
using Services.Abstractions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Controller.Tests
{
    public class TestEmployeeController
    {
        private Mock<IServiceManager> serviceManagerMock;
        private EmployeeController employeeController;

        public TestEmployeeController() {
            this.serviceManagerMock = new Mock<IServiceManager>();
            this.employeeController = new EmployeeController(serviceManagerMock.Object)
            {
                ControllerContext = new ControllerContext()
            };
        }

        [Fact]
        public async Task CreateEmployee_OnCreateNewUser()
        {
            var employee = new Employee
            {
                Id = new int(),
                Name = "test name",
                Email = "sadasdasds",
                JobTitle = "tester",
                Phone = "1212122",
                ImageUrl = "url test",
                EmployeeCode = Guid.NewGuid().ToString()
            };
            var employeeDto = new EmployeeForCreationDto
            {
                Name = "test name",
                Email = "sadasdasds",
                JobTitle = "tester",
                Phone = "1212122",
                ImageUrl = "url test",
            };

            serviceManagerMock
                .Setup(service => service.EmployeeService.CreateEmployeeAsync(It.IsAny<EmployeeForCreationDto>()))
                .Returns(() =>
                {
                    return Task.FromResult(employee);
                });

            Assert.IsType<OkObjectResult>(await this.employeeController.CreateEmployee(employeeDto));
        }



    }
}

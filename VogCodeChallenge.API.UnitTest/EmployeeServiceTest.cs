using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using VogCodeChallenge.API.Controllers;
using VogCodeChallenge.API.DataModel;
using VogCodeChallenge.API.IService;
using VogCodeChallenge.API.Model;
using VogCodeChallenge.API.Service;
using Xunit;

namespace VogCodeChallenge.API.UnitTest
{
  public class EmployeeServiceTest
  {
    private readonly EmployeeService _objEmployeeService;
    private readonly Mock<IEmployeeRepository> _employeeRepoMock = new Mock<IEmployeeRepository>();

    public EmployeeServiceTest()
    {
      _objEmployeeService = new EmployeeService(_employeeRepoMock.Object);
    }

    [Fact]
    public void GetAll_Positive_Test()
    {
      //Arrange
      var employeeResponse = TestData.GetEmployeesdto();
      _employeeRepoMock.Setup(x => x.GetAllEmpployee()).Returns(employeeResponse);

      //Act
      var result = _objEmployeeService.GetAll();
      IEnumerable<Employee> response = result;

      //Assert
      Assert.True(response != null);
    }

    [Fact]
    public void GetAll_Negative_Test()
    {
      //Arrange
      IEnumerable<Employeedto> nullResponse;
      nullResponse = null;

      _employeeRepoMock.Setup(x => x.GetAllEmpployee()).Returns(nullResponse);

      //Act
      var result = _objEmployeeService.GetAll();
      IEnumerable<Employee> response = result;

      //Assert
      Assert.True(response == null);
    }

    [Fact]
    public void ListAll_Positive_Test()
    {
      //Arrange
      var employeeResponse = TestData.GetEmployeesdto();
      _employeeRepoMock.Setup(x => x.ListAllEmployee()).Returns(employeeResponse);

      //Act
      var result = _objEmployeeService.GetAll();
      IEnumerable<Employee> response = result;

      //Assert
      Assert.True(response != null);
    }

    [Fact]
    public void ListAll_Negative_Test()
    {
      //Arrange
      IList<Employeedto> nullResponse;
      nullResponse = null;

      _employeeRepoMock.Setup(x => x.ListAllEmployee()).Returns(nullResponse);

      //Act
      var result = _objEmployeeService.ListAll();
      IList<Employee> response = result;

      //Assert
      Assert.True(response == null);
    }
  }
}

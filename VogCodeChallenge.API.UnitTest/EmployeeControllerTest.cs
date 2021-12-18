using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using VogCodeChallenge.API.Controllers;
using VogCodeChallenge.API.IService;
using VogCodeChallenge.API.Model;
using Xunit;

namespace VogCodeChallenge.API.UnitTest
{
  public class EmployeeControllerTest
  {

    private readonly EmployeesController _objEmplyee;
    private readonly Mock<IEmployeeService> _employeeServiceMock = new Mock<IEmployeeService>();
    private readonly Mock<IEmployeeRepository> _employeeRepoMock = new Mock<IEmployeeRepository>();

    public EmployeeControllerTest()
    {
      _objEmplyee = new EmployeesController(_employeeServiceMock.Object, _employeeRepoMock.Object);
    }


    [Fact]
    public void GetAllEmployee_Positive_Test()
    {
      //Arrange
      var employeeResponse = TestData.GetEmployeesModel();
      _employeeServiceMock.Setup(x => x.GetAll()).Returns(employeeResponse);

      //Act
      dynamic result = _objEmplyee.Get();
      ActionResult<ApiResponse<IEnumerable<Employee>>> response = result.Result.Value;

      //Assert
      Assert.True(response.Value.Result != null);

    }

    [Fact]
    public void GetAllEmployee_Negative_Test()
    {
      //Arrange
      var nullResponse = new List<Employee>();
      nullResponse = null;

      _employeeServiceMock.Setup(x => x.GetAll()).Returns(nullResponse);

      //Act
      dynamic result = _objEmplyee.Get();
      ActionResult<ApiResponse<IEnumerable<Employee>>> res = result.Result.Value;

      //Assert
      Assert.Null(res.Result);
    }

    [Fact]
    public void GetEmployeeByDepartment_Positive_Test()
    {
      //Arrange
      var employeeResponse = TestData.GetEmployeesModel();
      _employeeServiceMock.Setup(x => x.ListAll()).Returns(employeeResponse);

      //Act
      dynamic result = _objEmplyee.GetEmployeeByDepartment(2);
      ActionResult<ApiResponse<List<Employee>>> response = result.Result.Value;

      //Assert
      Assert.True(response.Value.Result != null);

    }

    [Fact]
    public void GetEmployeeByDepartment_Negative_Test()
    {
      //Arrange
      var employeeResponse = TestData.GetEmployeesModel();
      _employeeServiceMock.Setup(x => x.ListAll()).Returns(employeeResponse);

      //Act
      dynamic result = _objEmplyee.GetEmployeeByDepartment(5);
      ActionResult<ApiResponse<List<Employee>>> response = result.Result.Value;

      //Assert
      Assert.True(response.Value.Result.Count == 0);
    }


  }
}

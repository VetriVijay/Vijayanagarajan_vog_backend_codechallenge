using System;
using System.Collections.Generic;
using System.Text;
using VogCodeChallenge.API.DataModel;
using VogCodeChallenge.API.Model;

namespace VogCodeChallenge.API.UnitTest
{
  public static class TestData
  {

    public static List<Employee> GetEmployeesModel()
    {
      var employeeResponse = new List<Employee>()
      {
        new Employee()
        {
          EmployeeID=1,
            FirstName ="TestEmployee1FirstName",
            LastName="TestEmployee1LastName",
            Address="TestEmployee1Address",
            DepartmentID=1,
            UserID=1
        },
         new Employee()
        {
          EmployeeID=2,
            FirstName ="TestEmployee2FirstName",
            LastName="TestEmployee2LastName",
            Address="TestEmployee2Address",
            DepartmentID=1,
            UserID=1
        },
          new Employee()
        {
          EmployeeID=3,
            FirstName ="TestEmployee3FirstName",
            LastName="TestEmployee3LastName",
            Address="TestEmployee3Address",
            DepartmentID=1,
            UserID=1
        },
           new Employee()
        {
          EmployeeID=4,
            FirstName ="TestEmployee4FirstName",
            LastName="TestEmployee4LastName",
            Address="TestEmployee4Address",
            DepartmentID=2,
            UserID=1
        },
            new Employee()
        {
          EmployeeID=5,
            FirstName ="TestEmployee5FirstName",
            LastName="TestEmployee5LastName",
            Address="TestEmployee5Address",
            DepartmentID=2,
            UserID=1
        }

      };

      return employeeResponse;
    }

    public static List<Employeedto> GetEmployeesdto()
    {
      var employeeResponse = new List<Employeedto>()
      {
        new Employeedto()
        {
          EmployeeID=1,
            FirstName ="TestEmployee1FirstName",
            LastName="TestEmployee1LastName",
            Address="TestEmployee1Address",
            DepartmentID=1,
            UserID=1
        },
         new Employeedto()
        {
          EmployeeID=2,
            FirstName ="TestEmployee2FirstName",
            LastName="TestEmployee2LastName",
            Address="TestEmployee2Address",
            DepartmentID=1,
            UserID=1
        },
          new Employeedto()
        {
          EmployeeID=3,
            FirstName ="TestEmployee3FirstName",
            LastName="TestEmployee3LastName",
            Address="TestEmployee3Address",
            DepartmentID=1,
            UserID=1
        },
           new Employeedto()
        {
          EmployeeID=4,
            FirstName ="TestEmployee4FirstName",
            LastName="TestEmployee4LastName",
            Address="TestEmployee4Address",
            DepartmentID=2,
            UserID=1
        },
            new Employeedto()
        {
          EmployeeID=5,
            FirstName ="TestEmployee5FirstName",
            LastName="TestEmployee5LastName",
            Address="TestEmployee5Address",
            DepartmentID=2,
            UserID=1
        }

      };

      return employeeResponse;
    }
  }
}

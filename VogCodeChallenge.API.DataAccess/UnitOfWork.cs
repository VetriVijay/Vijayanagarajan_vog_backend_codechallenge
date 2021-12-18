using System;
using System.Collections.Generic;
using System.Text;
using VogCodeChallenge.API.DataModel;

namespace VogCodeChallenge.API.DataAccess
{
  public class UnitOfWork
  {
   
    public List<Employeedto> GetEmployeeSampleData()
    {
      List<Employeedto> objEmployeeList = new List<Employeedto>();
      Employeedto employeeData1 = new Employeedto();
      employeeData1.EmployeeID = 1;
      employeeData1.FirstName = "TestEmployee1FirstName";
      employeeData1.LastName = "TestEmployee1LastName";
      employeeData1.JobTitle = "TestEmployee1JobTitle";
      employeeData1.DepartmentID = 1;
      employeeData1.UserID = 1;
      employeeData1.IsActive = true;
      objEmployeeList.Add(employeeData1);

      Employeedto employeeData2 = new Employeedto();
      employeeData2.EmployeeID = 2;
      employeeData2.FirstName = "TestEmployee2FirstName";
      employeeData2.LastName = "TestEmployee2LastName";
      employeeData2.JobTitle = "TestEmployee2JobTitle";
      employeeData2.DepartmentID = 1;
      employeeData2.UserID = 1;
      employeeData2.IsActive = true;
      objEmployeeList.Add(employeeData2);


      Employeedto employeeData3 = new Employeedto();
      employeeData3.EmployeeID = 3;
      employeeData3.FirstName = "TestEmployee3FirstName";
      employeeData3.LastName = "TestEmployee3LastName";
      employeeData3.JobTitle = "TestEmployee3JobTitle";
      employeeData3.DepartmentID = 1;
      employeeData3.UserID = 1;
      employeeData3.IsActive = true;
      objEmployeeList.Add(employeeData3);


      Employeedto employeeData4 = new Employeedto();
      employeeData4.EmployeeID = 4;
      employeeData4.FirstName = "TestEmployee4FirstName";
      employeeData4.LastName = "TestEmployee4LastName";
      employeeData4.JobTitle = "TestEmployee4JobTitle";
      employeeData4.DepartmentID = 2;
      employeeData4.UserID = 2;
      employeeData4.IsActive = true;
      objEmployeeList.Add(employeeData4);


      Employeedto employeeData5 = new Employeedto();
      employeeData5.EmployeeID = 5;
      employeeData5.FirstName = "TestEmployee5FirstName";
      employeeData5.LastName = "TestEmployee5LastName";
      employeeData5.JobTitle = "TestEmployee5JobTitle";
      employeeData5.DepartmentID = 2;
      employeeData5.UserID = 2;
      employeeData5.IsActive = true;
      objEmployeeList.Add(employeeData5);

      return objEmployeeList;

    }
  }
}

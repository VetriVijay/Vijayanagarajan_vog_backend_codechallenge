using System;
using System.Collections.Generic;
using VogCodeChallenge.API.DataModel;
using VogCodeChallenge.API.IService;

namespace VogCodeChallenge.API.DataAccess
{
  public class EmployeeRepository : IEmployeeRepository
  {

    public IEnumerable<Employeedto> GetAllEmpployee()
    {
      //Instead of data from database we will retrieve test data.
      UnitOfWork unitOfWork = new UnitOfWork();
      List<Employeedto> objEmpList = unitOfWork.GetEmployeeSampleData();
      return (IEnumerable<Employeedto>)objEmpList;
    }

    public IList<Employeedto> ListAllEmployee()
    {
      //Instead of data from database we will retrieve test data.
      UnitOfWork unitOfWork = new UnitOfWork();
      List<Employeedto> objEmpList = unitOfWork.GetEmployeeSampleData();
      return objEmpList;
    }


  }
}

using AgileObjects.AgileMapper;
using System;
using System.Collections.Generic;
using VogCodeChallenge.API.IService;
using VogCodeChallenge.API.Model;

namespace VogCodeChallenge.API.Service
{
  public class EmployeeService : IEmployeeService
  {

    private readonly IEmployeeRepository employeeRepo;
    public EmployeeService(IEmployeeRepository _employeeRepository)
    {
      employeeRepo = _employeeRepository;

    }
    public IEnumerable<Employee> GetAll()
    {
      var employeeEnumResponse =  employeeRepo.GetAllEmpployee();
      IEnumerable<Employee> employeeModel = Mapper.Map(employeeEnumResponse).ToANew<IEnumerable<Employee>>();
      return employeeModel;
    }

    public IList<Employee> ListAll()
    {
      var employeeListResponse = employeeRepo.ListAllEmployee();
      IList<Employee> employeeModel = Mapper.Map(employeeListResponse).ToANew<IList<Employee>>();
      return employeeModel;
     }
  }
}

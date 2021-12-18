using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VogCodeChallenge.API.IService;
using VogCodeChallenge.API.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VogCodeChallenge.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeesController : ApiResultController
  {

    private readonly IEmployeeService employeeService;

    private readonly IEmployeeRepository employeeRepository;
    public EmployeesController(IEmployeeService _employeeService, IEmployeeRepository _employeeRepository)
    {
      employeeService = _employeeService;
      employeeRepository = _employeeRepository;
    }
    // GET: api/<EmployeesController>
    [HttpGet]
    public ActionResult<ApiResponse<IEnumerable<Employee>>> Get()
    {
      var employeeEnum =  employeeService.GetAll();
      return Ok(employeeEnum);

    }

    // GET api/EmployeesController/Department/5
    [HttpGet("Department/{DepartmentId}")]
    public ActionResult<ApiResponse<List<Employee>>> GetEmployeeByDepartment(int DepartmentId)
    {
      var employeeResponse = new List<Employee>();
      var employeeList = employeeService.ListAll();
      employeeResponse = employeeList.Where(x => x.DepartmentID == DepartmentId).Select(x => x).ToList();
      return Ok(employeeResponse);
    }

   
  }
}

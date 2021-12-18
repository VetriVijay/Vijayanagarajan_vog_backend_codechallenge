using System;
using System.Collections.Generic;
using System.Text;
using VogCodeChallenge.API.Model;

namespace VogCodeChallenge.API.IService
{
  public interface IEmployeeService
  {
    IEnumerable<Employee> GetAll();
    IList<Employee> ListAll();

    /* Similarly we can add methods related to Employee module to perform CRUD or any operations as per the requirement */

  }
}

using System;
using System.Collections.Generic;
using System.Text;
using VogCodeChallenge.API.DataModel;

namespace VogCodeChallenge.API.IService
{
  public interface IEmployeeRepository
  {

    IEnumerable<Employeedto> GetAllEmpployee();
    IList<Employeedto> ListAllEmployee();

    /* We can add other repository methods to perform data manipulation like add or delete in the database */

  }
}

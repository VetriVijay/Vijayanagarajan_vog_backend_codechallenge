using System;
using System.Collections.Generic;
using System.Text;

namespace VogCodeChallenge.API.Model
{
  /// <summary>
  /// Department - This model can be re-used in all the CRUD operation.
  /// </summary>
  public class Department
  {

    public int? Id { get; set; }

    public string DepartmentName { get; set; }

    public string DepartmentAddress { get; set; }

    public List<Employee> Employees { get; set; }

    public int? companyID { get; set; }

    //These two fields to audit the user and flag the data if required.
    public int? UserID { get; set; }

    public bool? IsActive { get; set; }


  }
}

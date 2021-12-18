using System;
using System.Collections.Generic;
using System.Text;

namespace VogCodeChallenge.API.Model
{
  /// <summary>
  /// Employee - This model can be re-used in all the CRUD operation.
  /// </summary>
  public class Employee
  {
    public int? EmployeeID { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string JobTitle { get; set; }

    public string Address { get; set; }

    public int? DepartmentID { get; set; }

    //These two fields to audit the user and flag the data if required.
    public int? UserID { get; set; }

    public bool? IsActive { get; set; }

  }
}

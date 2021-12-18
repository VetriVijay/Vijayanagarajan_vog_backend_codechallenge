using System;
using System.Collections.Generic;
using System.Text;

namespace VogCodeChallenge.API.DataModel
{
  public class Employeedto
  {
    public int? EmployeeID { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string JobTitle { get; set; }

    public string Address { get; set; }

    public int? DepartmentID { get; set; }

    public int? UserID { get; set; }

    public bool? IsActive { get; set; }

  }
}

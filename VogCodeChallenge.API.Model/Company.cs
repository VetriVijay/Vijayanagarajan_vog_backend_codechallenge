using System;
using System.Collections.Generic;

namespace VogCodeChallenge.API.Model
{
  /// <summary>
  /// Company - This model can be re-used in all the CRUD operation.
  /// </summary>
  public class Company
  {
    public int? Id { get; set; }

    public string CompanyName { get; set; }

    public List<Department> Departments { get; set; }

    //These two fields to audit the user and flag the data if required.
    public int? UserID { get; set; }

    public bool? IsActive { get; set; }

  }
}

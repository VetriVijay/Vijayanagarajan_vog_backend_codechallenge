using System;
using System.Collections.Generic;

namespace VogCodeChallenge.API.DataModel
{
  /// <summary>
  /// Companydto - Model to handle data in DAL.
  /// </summary>
  public class Companydto
  {

    public int? Id { get; set; }

    public string CompanyName { get; set; }

    public List<Departmentdto> Departments { get; set; }

    public int? UserID { get; set; }

    public bool? IsActive { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace VogCodeChallenge.API.DataModel
{
  public class Departmentdto
  {
    public int? Id { get; set; }

    public string DepartmentName { get; set; }

    public string DepartmentAddress { get; set; }

    public List<Employeedto> Employees { get; set; }

    public int? companyID { get; set; }

    public int? UserID { get; set; }

    public bool? IsActive { get; set; }
  }
}

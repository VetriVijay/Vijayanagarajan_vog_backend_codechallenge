using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VogCodeChallenge.API
{
  public class ApiResultController : Controller
  {
    [ApiExplorerSettings(IgnoreApi = true)]
    public new OkObjectResult Ok<T>(T data)
    {
      return base.Ok(new ApiResponse<T>(data));
    }
  }
}

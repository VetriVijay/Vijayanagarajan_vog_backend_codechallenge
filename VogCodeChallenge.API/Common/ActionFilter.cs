using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VogCodeChallenge.API
{
  public class ActionFilter : IAsyncActionFilter
  {
    private static string GetErrorMessage(ModelStateDictionary modelState)
    {
      string message = string.Join("; ", modelState.Values.SelectMany(x => x.Errors)
          .Select(x => x.ErrorMessage));
      if (!string.IsNullOrEmpty(message) && message.Equals(";"))
      {
        message = string.Join("; ", modelState.Values.SelectMany(x => x.Errors)
        .Select(x => x.Exception.Message));
      }
      return message;
    }

    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
      if (!context.ModelState.IsValid)
      {
        context.Result =
            new BadRequestObjectResult(new ApiResponse<bool>(false, GetErrorMessage(context.ModelState)));
      }
      else
      {
        await next.Invoke();
      }
    }

  }
}

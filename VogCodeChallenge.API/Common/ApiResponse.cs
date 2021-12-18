using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VogCodeChallenge.API
{
  public class ApiResponse<T>
  {
    public ApiResponse()
    {
      RequestTime = DateTime.UtcNow;
    }

    public ApiResponse(int messageCode)
    {
      MessageCode = messageCode;
      RequestTime = DateTime.UtcNow;
    }

    public ApiResponse(T content)
    {
      Result = content;
      RequestTime = DateTime.UtcNow;
    }
    public ApiResponse(T content, string errorMessage)
    {
      Result = content;
      Message = errorMessage;
      RequestTime = DateTime.UtcNow;
    }

    public ApiResponse(T content, int messageCode)
    {
      Result = content;
      MessageCode = messageCode;
      RequestTime = DateTime.UtcNow;
    }

    /// <summary>
    /// gets or sets http error codes
    /// </summary>
    public int MessageCode { get; set; }
    /// <summary>
    /// Get or sets Message
    /// </summary>
    public string Message { get; set; }
    /// <summary>
    /// get or sets Result
    /// </summary>
    public T Result { get; set; }
    /// <summary>
    /// Request hit time
    /// </summary>
    public DateTime RequestTime { get; set; }
  }
  /// <summary>
  /// object for api response
  /// </summary>
  public class ApiResponse : ApiResponse<object>
  {

  }
}


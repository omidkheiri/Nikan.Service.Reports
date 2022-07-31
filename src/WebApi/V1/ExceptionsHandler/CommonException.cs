using Microsoft.AspNetCore.Mvc;

namespace Nikan.Services.Reports.WebApi.V1.ExceptionsHandler;

public class CommonException
{

  /// <summary>
  /// Creates the validation problem details result.
  /// </summary>
  /// <param name="type">The type.</param>
  /// <param name="detail">The detail.</param>
  /// <param name="status">The status.</param>
  /// <returns></returns>
  public static ValidationProblemDetails CreateValidationProblemDetailsResult(
      string type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
      string detail = null,
      int status = 400)
  {
    return new ValidationProblemDetails()
    {
      Type = type,
      Title = "500-1",
      Detail = detail,
      Status = status
    };
  }

  /// <summary>
  /// Duplicates the resource problem.
  /// </summary>
  /// <param name="detail">The detail.</param>
  /// <param name="status">The status.</param>
  /// <returns></returns>
  public static ProblemDetails DuplicateResourceProblem(string detail = null, int status = 409)
  {
    return new ProblemDetails
    {
      Type = "https://tools.ietf.org/html/rfc7231#section-6.5.8",
      Title = "500-2",
      Detail = detail,
      Status = status
    };
  }

  /// <summary>
  /// Nots the found problem.
  /// </summary>
  /// <param name="detail">The detail.</param>
  /// <returns></returns>
  public static ProblemDetails NotFoundProblem(string detail = null)
  {
    return new ProblemDetails
    {
      Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
      Title = "500-3",
      Detail = detail,
      Status = 404
    };
  }
}


using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ambev.DeveloperEvaluation.WebApi.Common;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected int GetCurrentUserId() =>
            int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NullReferenceException());

    protected string GetCurrentUserEmail() =>
        User.FindFirst(ClaimTypes.Email)?.Value ?? throw new NullReferenceException();

    protected IActionResult Ok<T>(T data) =>
            base.Ok(new ApiResponseWithData<T> { Data = data, Success = true });

    protected IActionResult Created<T>(string routeName, object routeValues, T data) =>
        base.CreatedAtRoute(routeName, routeValues, new ApiResponseWithData<T> { Data = data, Success = true });

    protected IActionResult BadRequest(string message) =>
        base.BadRequest(new ApiResponse { Message = message, Success = false });

    protected IActionResult NotFound(string message = "Resource not found") =>
        base.NotFound(new ApiResponse { Message = message, Success = false });

    protected IActionResult OkPaginated<T>(PaginatedList<T> pagedList) =>
            Ok(new PaginatedResponse<T>
            {
                Data = pagedList,
                CurrentPage = pagedList.CurrentPage,
                TotalPages = pagedList.TotalPages,
                TotalCount = pagedList.TotalCount,
                Success = true
            });

    protected async Task<IActionResult> ValidatedRequest<TValidator, TSubject>
        (TValidator validator, TSubject subject, Func<TSubject,Task<IActionResult>> request, CancellationToken cancellationToken=default)
        where TValidator : AbstractValidator<TSubject>
    {
        var result = await validator.ValidateAsync(subject, cancellationToken);

        if (result.IsValid) return await request(subject);

        return base.BadRequest(result.Errors);
    }

    protected IActionResult HandlingError(Error error)
    {
        switch (error.Type)
        {
            case ErrorType.Unauthorized:return Unauthorized(error.Description);
            case ErrorType.Forbidden:   return Forbid(error.Description);
            case ErrorType.NotFound:    return NotFound(error.Description);
            case ErrorType.Validation:  return BadRequest(error.Description);
            case ErrorType.Failure:     return StatusCode(500,error.Description);
            case ErrorType.Unexpected:  return StatusCode(418, error.Description);
            default: return BadRequest(error.Description);
        }

    }
}

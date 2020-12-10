using System;
using Microsoft.AspNetCore.Mvc;
using MediatR.Commands.Results;
using MediatR.Commands.BodyTypes;

namespace MediatR.Commands.AspnetCoreExtensions
{
    public static class ActionResultExtensions
    {
        public static IActionResult ToActionResult(this IResult result)
        {
            Type resultType = result.GetType();
            
            if (resultType.IsGenericType)
            {
                Type genericTypeDefinition = resultType.GetGenericTypeDefinition();
                if (genericTypeDefinition == typeof(CreatedResult<>)) return new OkObjectResult(result.Body) { StatusCode = 201 };
                if (genericTypeDefinition == typeof(DeletedResult<>)) return new NoContentResult();
            }
            
            if (result is Results.NotFoundResult) return new Microsoft.AspNetCore.Mvc.NotFoundResult();
            if (result is Results.UnauthorizedResult) return new UnauthorizedObjectResult(result.Body);
            if (result is Results.ForbiddenResult) return new StatusCodeResult(403);
            if (result is InvalidInputResult) return new BadRequestObjectResult(result.Body);
            if (result is ExceptionResult)
            {
                var e = result.Body as ExceptionBody;
                return new OkObjectResult(e.Exception.Message) { StatusCode = 500 };
            }
            return new OkObjectResult(result.Body);
        }
    }
}
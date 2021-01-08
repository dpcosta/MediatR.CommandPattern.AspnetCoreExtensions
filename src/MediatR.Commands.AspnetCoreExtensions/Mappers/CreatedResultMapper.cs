using System;
using MediatR.Commands.Results;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.Commands.AspnetCoreExtensions.Mappers
{
  internal class CreatedResultMapper : ResultMapper
  {
    internal override IActionResult Map(IResult from)
    {
        Type resultType = from.GetType();
        if (resultType.IsGenericType)
        {
            Type genericTypeDefinition = resultType.GetGenericTypeDefinition();
            if (genericTypeDefinition == typeof(CreatedResult<>)) return new OkObjectResult(from.Body) { StatusCode = 201 };
        }
        return null;
    }
  }
}
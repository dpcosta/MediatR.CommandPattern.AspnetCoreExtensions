using System;
using Microsoft.AspNetCore.Mvc;
using MediatR.Commands.Results;

namespace MediatR.Commands.AspnetCoreExtensions.Mappers
{
    internal class UpdatedResultMapper : ResultMapper
    {
        internal override IActionResult Map(IResult from)
        {
            Type resultType = from.GetType();
            if (resultType.IsGenericType)
            {
                Type genericTypeDefinition = resultType.GetGenericTypeDefinition();
                if (genericTypeDefinition == typeof(UpdatedResult<>)) return new OkObjectResult(from.Body);
            }
            return null;
        }
    }
}

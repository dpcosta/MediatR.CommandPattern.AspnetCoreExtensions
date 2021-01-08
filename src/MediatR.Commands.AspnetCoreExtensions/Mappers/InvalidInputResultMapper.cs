using Microsoft.AspNetCore.Mvc;
using MediatR.Commands.Results;

namespace MediatR.Commands.AspnetCoreExtensions.Mappers
{
  internal class InvalidInputResultMapper : ResultMapper
  {
    internal override IActionResult Map(IResult from)
    {
        if (from is InvalidInputResult) return new BadRequestObjectResult(from.Body);
        return null;
    }
  }
}
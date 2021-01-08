using Microsoft.AspNetCore.Mvc;
using MediatR.Commands.Results;

namespace MediatR.Commands.AspnetCoreExtensions.Mappers
{
  internal class UnauthorizedResultMapper : ResultMapper
  {
    internal override IActionResult Map(IResult from)
    {
        if (from is Results.UnauthorizedResult) return new UnauthorizedObjectResult(from.Body);
        return null;
    }
  }
}
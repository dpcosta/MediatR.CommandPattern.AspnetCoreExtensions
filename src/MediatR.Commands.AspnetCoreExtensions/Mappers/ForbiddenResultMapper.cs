using MediatR.Commands.Results;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.Commands.AspnetCoreExtensions.Mappers
{
  internal class ForbiddenResultMapper : ResultMapper
  {
    internal override IActionResult Map(IResult from)
    {
        if (from is Results.ForbiddenResult) return new StatusCodeResult(403);
        return null;
    }
  }
}
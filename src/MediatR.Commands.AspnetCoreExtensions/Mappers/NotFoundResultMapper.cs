using Microsoft.AspNetCore.Mvc;
using MediatR.Commands.Results;

namespace MediatR.Commands.AspnetCoreExtensions.Mappers
{
  internal class NotFoundResultMapper : ResultMapper
  {
        internal override IActionResult Map(IResult from)
        {
            if (from is Results.NotFoundResult) return new Microsoft.AspNetCore.Mvc.NotFoundResult();
            return null;
        }
  }
}
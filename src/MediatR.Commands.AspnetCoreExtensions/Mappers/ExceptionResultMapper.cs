using Microsoft.AspNetCore.Mvc;
using MediatR.Commands.Results;
using MediatR.Commands.BodyTypes;

namespace MediatR.Commands.AspnetCoreExtensions.Mappers
{
  internal class ExceptionResultMapper : ResultMapper
  {
    internal override IActionResult Map(IResult from)
    {
        if (from is ExceptionResult)
        {
            var e = from.Body as ExceptionBody;
            return new ObjectResult(e.Exception.Message) { StatusCode = 500 };
        }
        return null;
    }
  }
}
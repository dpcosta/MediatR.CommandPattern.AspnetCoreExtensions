using Microsoft.AspNetCore.Mvc;
using MediatR.Commands.BodyTypes;
using MediatR.Commands.Results;

namespace MediatR.Commands.AspnetCoreExtensions.Mappers
{
  internal class ErrorResultMapper : ResultMapper
  {
    internal override IActionResult Map(IResult from)
    {
        if (from is ErrorResult)
        {
            var m = from.Body as MessageBody;
            return new ObjectResult(new { ErrorMessage = m.Message }) { StatusCode = 500 };
        }
        return null;
    }
  }
}
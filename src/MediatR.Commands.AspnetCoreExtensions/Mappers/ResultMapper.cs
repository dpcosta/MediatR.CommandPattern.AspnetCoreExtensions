using Microsoft.AspNetCore.Mvc;
using MediatR.Commands.Results;

namespace MediatR.Commands.AspnetCoreExtensions.Mappers
{
    internal abstract class ResultMapper
    {
        internal abstract IActionResult Map(IResult from);
    }
}
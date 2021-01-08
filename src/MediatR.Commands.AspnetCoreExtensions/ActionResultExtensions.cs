using Microsoft.AspNetCore.Mvc;
using MediatR.Commands.Results;
using MediatR.Commands.AspnetCoreExtensions.Mappers;

namespace MediatR.Commands.AspnetCoreExtensions
{
    public static class ActionResultExtensions
    {
        public static IActionResult ToActionResult(this IResult result)
        {
            return GenericResultMapper.Map(result);
        }
    }
}
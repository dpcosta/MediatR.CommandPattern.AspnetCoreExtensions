using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MediatR.Commands.Results;

namespace MediatR.Commands.AspnetCoreExtensions.Mappers
{
  internal static class GenericResultMapper
  {
    internal static IActionResult Map(IResult from)
    {
        IActionResult to = null;

        // get instances of all classes that inherits ResultMapper and have a parameterless constructor
        IEnumerable<ResultMapper> lista = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => !t.IsAbstract && typeof(ResultMapper).IsAssignableFrom(t) && (t.GetConstructor(Type.EmptyTypes)!=null) )
            .Select(m => Activator.CreateInstance(m) as ResultMapper)
            .ToList();

        foreach(var mapper in lista)
        {
            to = mapper.Map(from);
            // if IResult is mapped then leave
            if (to != null) return to;
        }

        // or else
        return new OkObjectResult(from.Body);
    }
  }
}
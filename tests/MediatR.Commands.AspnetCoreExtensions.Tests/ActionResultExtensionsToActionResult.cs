using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using MediatR.Commands.Results;

namespace MediatR.Commands.AspnetCoreExtensions.Tests
{
    public class ActionResultExtensionsToActionResult
    {
        public static IEnumerable<object[]> ResultTypeInputAndExpectedActionResultType => new List<object[]>
        {
            new object[] { new ErrorResult("Testes"), typeof(ObjectResult)},
            new object[] { new CreatedResult<string>("Testes"), typeof(OkObjectResult) },
            new object[] { new UpdatedResult<string>("Testes"), typeof(OkObjectResult) },
            new object[] { new DeletedResult<string>("Testes"), typeof(NoContentResult) },
            new object[] { new Results.NotFoundResult(), typeof(Microsoft.AspNetCore.Mvc.NotFoundResult) },
            new object[] { new Results.UnauthorizedResult(), typeof(UnauthorizedObjectResult) },
            new object[] { new InvalidInputResult("Testes"), typeof(BadRequestObjectResult) },
            new object[] { new ExceptionResult(new Exception("Testes")), typeof(ObjectResult) }
        };

        public static IEnumerable<object[]> ResultTypeInputAndExpectedStatusCode => new List<object[]>
        {
            new object[] { new CreatedResult<string>("Testes"), 201 },
            new object[] { new UpdatedResult<string>("Testes"), 200 },
            new object[] { new DeletedResult<string>("Testes"), 204 },
            new object[] { new Results.NotFoundResult(), 404 },
            new object[] { new Results.UnauthorizedResult(), 401 },
            new object[] { new InvalidInputResult("Testes"), 400 },
            new object[] { new ExceptionResult(new Exception("Testes")), 500 },
            new object[] { new ErrorResult("Testes"), 500 }
        };

        [Theory]
        [MemberData(nameof(ResultTypeInputAndExpectedActionResultType))]
        public void ShouldConvertToExpectedActionResultType(IResult commandResult, Type expectedType)
        {
            // arrange: from method arguments

            // act
            var result = commandResult.ToActionResult();

            // assert
            Assert.IsType(expectedType, result);
        }

        [Theory]
        [MemberData(nameof(ResultTypeInputAndExpectedStatusCode))]
        public void ShouldReturnExpectedStatusCode(IResult commandResult, int expectedStatusCode)
        {
            // arrange from method arguments

            // act
            var result = commandResult.ToActionResult();
            var statusCode = (int)result.GetType().GetProperty("StatusCode").GetValue(result);

            // assert
            Assert.Equal(expectedStatusCode, statusCode);
        }

        [Fact]
        public void ShouldReturnMessageTextOnErrorResult()
        {
            // arrange
            string expectedMessage = "Testes";
            IResult errorResult = new ErrorResult(expectedMessage);

            // act
            var result = errorResult.ToActionResult();

            // assert
            var obj = result.GetType().GetProperty("Value").GetValue(result);
            Assert.Single(obj.GetType().GetProperties().Where(p => p.Name == "ErrorMessage"));
            var message = (string)obj.GetType().GetProperty("ErrorMessage").GetValue(obj);
            Assert.Equal(expectedMessage, message);
        }
    }
}

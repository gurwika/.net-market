using MRKT.Common.Application.Common.Models;
using System.Collections.Generic;
using Xunit;

namespace MRKT.Common.Application.test.Models
{
    public class ResultTests
    {
        [Fact]
        public void ShouldMatchSuccessStatus()
        {
            var successResult = Result.Success();

            Assert.True(successResult.Succeeded);
            Assert.Empty(successResult.Errors);
        }

        [Fact]
        public void ShouldMatchFailureStatus()
        {
            var errorList = new List<string>()
            {
                "validation error"
            };

            var successResult = Result.Failure(errorList);

            Assert.False(successResult.Succeeded);
            Assert.NotEmpty(successResult.Errors);
            Assert.Single(successResult.Errors);
        }
    }
}

using FluentValidation.Results;
using ForEvolve.OperationResults.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ForEvolve.OperationResults.Validations
{
    public class MapperIntegrationTest
    {
        [Fact]
        public void IValidationFailureMapper_should_convert_ValidationFailure_to_the_expected_IMessage()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddValidationBehaviorMapper();
            var serviceProvider = services.BuildServiceProvider();

            var sut = serviceProvider.GetService<IValidationFailureMapper>();
            var validationFailure = new ValidationFailure(
                propertyName: "TestProperty",
                errorMessage: "Test Error Message"
            ) {
                ErrorCode = "Error0123",
            };

            // Act
            var actual = sut.Map(validationFailure);

            // Assert
            var message = Assert.IsType<ProblemDetailsMessage>(actual);
            Assert.Equal(OperationMessageLevel.Error, actual.Severity);
            Assert.Equal("Error0123", message.ProblemDetails.Title);
            Assert.Equal("Error0123", actual.Details["title"]);
            Assert.Equal("Test Error Message", message.ProblemDetails.Detail);
            Assert.Equal("Test Error Message", actual.Details["detail"]);
            Assert.Equal("TestProperty", message.ProblemDetails.Extensions["propertyName"]);
            Assert.Equal("TestProperty", actual.Details["propertyName"]);
        }
    }
}

using FluentValidation;
using FluentValidation.Results;
using ForEvolve.OperationResults.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ForEvolve.OperationResults.Validations
{
    public class ValidationFailureMessageMapperTest
    {
        public class Map : ValidationFailureMessageMapperTest
        {
            [Fact]
            public void Should_map_ValidationFailure_to_IMessage()
            {
                // Arrange
                var details = new ProblemDetails();
                var severityMapperMock = new Mock<IValidationSeverityMapper>();
                severityMapperMock
                    .Setup(x => x.Map(It.IsAny<Severity>()))
                    .Returns(OperationMessageLevel.Error);
                var problemDetailsMapperMock = new Mock<IProblemDetailsMapper>();
                problemDetailsMapperMock
                    .Setup(x => x.Map(It.IsAny<ValidationFailure>()))
                    .Returns(details);
                var sut = new ValidationFailureMessageMapper(
                    severityMapperMock.Object,
                    problemDetailsMapperMock­.Object
                );
                var validationFailure = new ValidationFailure("PropName", "Test Error");

                // Act
                var actual = sut.Map(validationFailure);

                // Assert
                var actualMessage = Assert.IsType<ProblemDetailsMessage>(actual);
                Assert.Same(details, actualMessage.ProblemDetails);
                Assert.Equal(OperationMessageLevel.Error, actualMessage.Severity);
            }
        }
    }
}

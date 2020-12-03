using Castle.DynamicProxy.Generators;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ForEvolve.OperationResults.Validations
{
    public class SimpleProblemDetailsMapperTest
    {
        public class Map : SimpleProblemDetailsMapperTest
        {
            [Fact]
            public void Should_map_ErrorCode_to_Title()
            {
                // Arrange
                var sut = new SimpleProblemDetailsMapper();
                var validationFailure = new ValidationFailure("TestProp", "Test error")
                {
                    ErrorCode = "Code123",
                };

                // Act
                var actual = sut.Map(validationFailure);

                // Assert
                Assert.Equal("Code123", actual.Title);
            }

            [Fact]
            public void Should_map_ErrorMessage_to_Detail()
            {
                // Arrange
                var sut = new SimpleProblemDetailsMapper();
                var validationFailure = new ValidationFailure("TestProp", "Test error")
                {
                    ErrorCode = "Code123",
                };

                // Act
                var actual = sut.Map(validationFailure);

                // Assert
                Assert.Equal("Test error", actual.Detail);
            }


            [Fact]
            public void Should_map_PropertyName_to_Extensions()
            {
                // Arrange
                var sut = new SimpleProblemDetailsMapper();
                var validationFailure = new ValidationFailure("TestProp", "Test error")
                {
                    ErrorCode = "Code123",
                };

                // Act
                var actual = sut.Map(validationFailure);

                // Assert
                Assert.Equal("TestProp", actual.Extensions["propertyName"]);
            }
        }
    }
}

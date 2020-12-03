using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ForEvolve.OperationResults.Validations
{
    public class DefaultValidationSeverityMapperTest
    {
        public class Map : DefaultValidationSeverityMapperTest
        {
            [Theory]
            [InlineData(Severity.Warning, OperationMessageLevel.Warning)]
            [InlineData(Severity.Info, OperationMessageLevel.Information)]
            [InlineData(Severity.Error, OperationMessageLevel.Error)]
            [InlineData(((Severity)(-1)), OperationMessageLevel.Error)]
            public void Should_map_the_specified_Severity_to_the_expected_OperationMessageLevel(Severity severity, OperationMessageLevel expected)
            {
                // Arrange
                var sut = new DefaultValidationSeverityMapper();

                // Act
                var actual = sut.Map(severity);

                // Assert
                Assert.Equal(expected, actual);
            }

        }
    }
}

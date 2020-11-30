using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ForEvolve.FluentValidation.Validators
{
    public class UriValidatorTest
    {
        public class IsValid
        {
            [Theory]
            [InlineData("", true)]
            [InlineData(null, true)]
            [InlineData("/", true)]
            [InlineData("/something", true)]
            [InlineData("/something/", true)]
            [InlineData("something", true)]
            [InlineData("something/", true)]
            [InlineData("something/else", true)]
            [InlineData("some-filename.ext", true)]
            [InlineData("something/some-filename.ext", true)]
            [InlineData("/something/some-filename.ext", true)]
            [InlineData("c:/something/else", false)]
            [InlineData("\\some\\thing", false)]
            public void Should_be(string path, bool expectedOutcome)
            {
                // Arrange
                var validator = new InlineValidator<Model>();
                validator
                    .RuleFor(x => x.Path)
                    .Uri(UriKind.Relative);
                var model = new Model { Path = path };

                // Act
                var result = validator.Validate(model);

                // Assert
                Assert.Equal(expectedOutcome, result.IsValid);
            }
        }

        public class Model
        {
            public string Path { get; set; }
        }
    }
}

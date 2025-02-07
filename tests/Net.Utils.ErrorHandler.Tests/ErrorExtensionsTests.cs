using Xunit;
using FluentAssertions;
using Net.Utils.ErrorHandler.Extensions;

namespace Net.Utils.ErrorHandler.Tests;

public class ErrorExtensionsTests
{
    public class ToErrorCode
    {
        [Theory]
        [InlineData(Error.INTERNAL_SERVER_ERROR, "INTERNAL_SERVER_ERROR")]
        [InlineData(Error.NOT_FOUND, "NOT_FOUND")]
        internal void ShouldReturnsStringRepresentationOfEnumMember(Error error, string expected)
        {
            var errorCode = error.ToErrorCode();
            errorCode.Should().Be(expected);
        }
    }

    public class ToErrorMessage
    {
        [Theory]
        [InlineData(Error.INTERNAL_SERVER_ERROR, ErrorMessages.INTERNAL_SERVER_ERROR)]
        [InlineData(Error.NOT_FOUND, ErrorMessages.NOT_FOUND)]
        internal void WhenAttributeImplemented_ShouldReturnsExpectedMessage(Error error, string expected)
        {
            var errorMessage = error.ToErrorMessage();
            errorMessage.Should().Be(expected);
        }

        [Fact]
        internal void WhenAttributeNotImplemented_ShouldThrowArgumentException()
        {
            var testCode = () => Error.ENUM_MEMBER_WITHOUT_ERROR_ATTRIBUTE.ToErrorMessage();
            testCode.Should().Throw<ArgumentException>()
                .WithMessage("Member 'ENUM_MEMBER_WITHOUT_ERROR_ATTRIBUTE' of 'Net.Utils.ErrorHandler.Tests.Error' enum must implement 'ErrorAttribute' attribute. (Parameter 'error')");
        }
    }
}
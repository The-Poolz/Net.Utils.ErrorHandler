using System;
using FluentValidation;
using System.Reflection;
using FluentValidation.Results;
using Net.Utils.ErrorHandler.Attributes;

namespace Net.Utils.ErrorHandler.Extensions
{
    public static class ErrorExtensions
    {
        public static ValidationException ToException(this Enum error, object? customState = null, string propertyName = "")
        {
            var errorMessage = error.ToErrorMessage();
            var failure = new ValidationFailure(propertyName, errorMessage)
            {
                ErrorCode = error.ToErrorCode(),
                CustomState = customState
            };
            return new ValidationException(errorMessage, new []{ failure });
        }

        public static string ToErrorCode(this Enum error)
        {
            return error.ToString();
        }

        public static string ToErrorMessage(this Enum error)
        {
            return error
                .GetType()
                .GetField(error.ToString())!
                .GetCustomAttribute<ErrorAttribute>()!
                .Message;
        }
    }
}

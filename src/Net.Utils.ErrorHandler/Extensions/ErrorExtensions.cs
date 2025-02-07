using System;
using FluentValidation;
using System.Reflection;
using FluentValidation.Results;
using Net.Utils.ErrorHandler.Attributes;

namespace Net.Utils.ErrorHandler.Extensions
{
    public static class ErrorExtensions
    {
        public static ValidationException ToException<TEnum>(this TEnum error, object? customState = null, string propertyName = "")
            where TEnum : Enum
        {
            var errorMessage = error.ToErrorMessage();
            var failure = new ValidationFailure(propertyName, errorMessage)
            {
                ErrorCode = error.ToErrorCode(),
                CustomState = customState
            };
            return new ValidationException(errorMessage, new []{ failure });
        }

        public static string ToErrorCode<TEnum>(this TEnum error)
            where TEnum : Enum
        {
            return error.ToString();
        }

        public static string ToErrorMessage<TEnum>(this TEnum error)
            where TEnum : Enum
        {
            var field = error.GetType().GetField(error.ToString());
            var attribute = field.GetCustomAttribute<ErrorAttribute>();
            return attribute?.Message ?? throw new ArgumentException($"Member '{field.Name}' of '{typeof(TEnum).FullName}' enum must implement '{nameof(ErrorAttribute)}' attribute.", nameof(error));
        }
    }
}

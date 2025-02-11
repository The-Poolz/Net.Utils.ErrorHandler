using System;
using FluentValidation;

namespace Net.Utils.ErrorHandler.Extensions
{
    public static class RuleBuilderOptionsExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, Enum error, object? customState = null)
        {
            return rule
                .WithState(_ => customState)
                .WithErrorCode(error)
                .WithErrorMessage(error);
        }

        public static IRuleBuilderOptions<T, TProperty> WithErrorMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, Enum error)
        {
            return rule.WithMessage(error.ToErrorMessage());
        }

        public static IRuleBuilderOptions<T, TProperty> WithErrorCode<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, Enum error)
        {
            return rule.WithErrorCode(error.ToErrorCode());
        }
    }
}

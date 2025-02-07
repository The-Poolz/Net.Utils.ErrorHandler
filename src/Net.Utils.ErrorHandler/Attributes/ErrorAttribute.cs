using System;

namespace Net.Utils.ErrorHandler.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ErrorAttribute : Attribute
    {
        public ErrorAttribute(string errorMessage)
        {
            Message = errorMessage;
        }

        public string Message { get; }
    }
}

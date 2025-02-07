using Net.Utils.ErrorHandler.Attributes;

namespace Net.Utils.ErrorHandler.Tests;

internal enum Error
{
    [Error(ErrorMessages.INTERNAL_SERVER_ERROR)]
    INTERNAL_SERVER_ERROR,

    [Error(ErrorMessages.NOT_FOUND)]
    NOT_FOUND,

    ENUM_MEMBER_WITHOUT_ERROR_ATTRIBUTE
}
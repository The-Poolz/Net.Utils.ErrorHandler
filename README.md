# Net.Utils.ErrorHandler

A C# library for managing error handling through enums and custom attributes.
This package simplifies error management by allowing you to define errors as enum members decorated with a custom attribute and then convert them into `FluentValidation` exceptions.

---

## Installation

.NET CLI
```powershell
dotnet add package Net.Utils.ErrorHandler
```

Package Manager
```powershell
Install-Package Net.Utils.ErrorHandler
```

## Features

- **Enum-Based Error Definitions:** Define all your error codes in a single enum and associate each member with a specific error message using the `[Error]` attribute.
- **FluentValidation Integration:** Convert enum errors directly into a `ValidationException`, which is useful when working with `FluentValidation`.
- **Customizable Error Information:** Attach custom state and property names to errors when converting them, providing additional context for error handling.

---

## Installation

Install the package via the .NET CLI:

```powershell
dotnet add package Net.Utils.ErrorHandler
```

Or via the Package Manager:

```powershell
Install-Package Net.Utils.ErrorHandler
```

---

## Usage

### 1. Define Your Error Enum

Decorate each enum member with the `[Error]` attribute to specify the corresponding error message.

```csharp
using Net.Utils.ErrorHandler.Attributes;

public enum Error
{
    [Error("Internal server error occurred.")]
    InternalServerError,

    [Error("The requested resource was not found.")]
    NotFound,

    // Note: Enum members without the Error attribute will throw an exception when used.
    UndefinedError
}
```

### 2. Convert Enum Errors to Exceptions

Use the extension methods provided in the `Net.Utils.ErrorHandler.Extensions` namespace to convert your enum errors into a FluentValidation `ValidationException`.

```csharp
using FluentValidation;
using Net.Utils.ErrorHandler.Extensions;

public class SomeService
{
    public void Process()
    {
        // Throw an exception for a simple error
        throw Error.NotFound.ToException();

        // Throw an exception with additional custom state and property name
        var customData = new { Detail = "Additional error information." };
        throw Error.InternalServerError.ToException(customData, "SomeProperty");
    }
}
```

### 3. Retrieve Error Codes and Messages

You can also retrieve the error code (the enum member's name) and the associated error message:

```csharp
using Net.Utils.ErrorHandler.Extensions;

var errorCode = Error.NotFound.ToErrorCode();       // Returns "NotFound"
var errorMessage = Error.NotFound.ToErrorMessage();   // Returns "The requested resource was not found."
```

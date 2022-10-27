# What is it for?

Library responsible for exposing facilitators for common tests and asserts.

# Methods

### LoggerAsserts

#### Mock<ILogger<T>>.VerifyLogHasCalled()

Validate using MOQ if a log event was executed within the of a method.

```csharp
    private readonly Mock<ILogger<ServiceTest>> _loggerMock = new Mock<ILogger<ServiceTest>>();

    public void Test()
    {
        var message = "Log error.";

        var service = new ServiceTest(_loggerMock.Object);
        service.ExecuteTestMethod(message);

        _loggerMock.VerifyLogHasCalled(LogLevel.Information, message, Times.Once);
    }
```
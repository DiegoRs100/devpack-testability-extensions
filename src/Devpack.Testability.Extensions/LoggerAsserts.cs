using Microsoft.Extensions.Logging;
using Moq;

namespace Devpack.Testability.Extensions
{
    public static class LoggerAsserts
    {
        public static Mock<ILogger<T>> VerifyLogHasCalled<T>(this Mock<ILogger<T>> logger, LogLevel logLevel, string expectedMessage, Func<Times> times)
        {
            Func<object, Type, bool> state = (v, t) => v.ToString() == expectedMessage;

            logger.Verify(x => x.Log(
                It.Is<LogLevel>(l => l == logLevel),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => state(v, t)),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)!), times);

            return logger;
        }
    }
}
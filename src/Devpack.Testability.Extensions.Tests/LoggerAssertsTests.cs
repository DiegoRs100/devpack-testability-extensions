using Devpack.Testability.Extensions.Tests.Common;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace Devpack.Testability.Extensions.Tests
{
    public class LoggerAssertsTests
    {
        private readonly Mock<ILogger<ServiceTest>> _loggerMock;

        public LoggerAssertsTests()
        {
            _loggerMock = new Mock<ILogger<ServiceTest>>();
        }

        [Fact(DisplayName = "Deve indicar que um log foi disparado quando o método que está sendo testado tiver disparado um log.")]
        [Trait("Category", "Extensions")]
        public void VerifyLogHasCalled_WhenTrue()
        {
            var message = Guid.NewGuid().ToString();

            var service = new ServiceTest(_loggerMock.Object);
            service.ExecuteInformationLog(message);

            _loggerMock.VerifyLogHasCalled(LogLevel.Information, message, Times.Once);
        }

        [Fact(DisplayName = "Deve indicar que um log não foi disparado quando o método que está sendo testado não tiver disparado um log.")]
        [Trait("Category", "Extensions")]
        public void VerifyLogHasCalled_WhenFalse()
        {
            var message = Guid.NewGuid().ToString();

            _ = new ServiceTest(_loggerMock.Object);
            _loggerMock.VerifyLogHasCalled(LogLevel.Information, message, Times.Never);
        }
    }
}
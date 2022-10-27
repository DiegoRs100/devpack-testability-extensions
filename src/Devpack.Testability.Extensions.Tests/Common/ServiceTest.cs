using Microsoft.Extensions.Logging;

namespace Devpack.Testability.Extensions.Tests.Common
{
    public class ServiceTest
    {
        private readonly ILogger<ServiceTest> _logger;

        public ServiceTest(ILogger<ServiceTest> logger)
        {
            _logger = logger;
        }

        public void ExecuteInformationLog(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
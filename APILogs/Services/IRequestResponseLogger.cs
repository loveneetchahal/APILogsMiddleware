﻿namespace APILogs.Services
{
    public interface IRequestResponseLogger
    {
        void Log(IRequestResponseLogModelCreator logCreator);
    }

    public class RequestResponseLogger : IRequestResponseLogger
    {
        private readonly ILogger<RequestResponseLogger> _logger;

        public RequestResponseLogger(ILogger<RequestResponseLogger> logger)
        {
            _logger = logger;
        }
        public void Log(IRequestResponseLogModelCreator logCreator)
        {
            //_logger.LogTrace(jsonString);
            //_logger.LogInformation(jsonString);
            //_logger.LogWarning(jsonString);
            _logger.LogCritical(logCreator.LogString());
        }
    }
}

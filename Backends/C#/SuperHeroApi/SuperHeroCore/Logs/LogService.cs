using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog.Context;
using Serilog.Events;
using SuperHeroCore.Logs.Behavior;
using SuperHeroCore.Logs.Model;
using System;
using System.Collections.Generic;

namespace SuperHeroCore.Logs
{
    public class LogService : ILogService
    {
        readonly ILogger<LogService> _logger;

        public LogService(ILogger<LogService> logger)
        {
            _logger = logger;
        }

        public void LogError(string message, Exception exception = null, object data = null)
        {
            WriteLog(LogEventLevel.Error, message, exception, data);
        }

        public void LogInfo(string message, object data = null)
        {
            WriteLog(LogEventLevel.Information, message, null, data);
        }

        public void LogWarning(string message, Exception exception = null, object data = null)
        {
            WriteLog(LogEventLevel.Warning, message, exception, data);
        }

        public void Write(IList<LogInfo> logInfos, string acronym = "")
        {
            foreach (var log in logInfos)
            {
                Write(log, acronym);
            }
        }

        public void Write(LogInfo logInfo, string acronym = "")
        {
            var levelId = (int)logInfo.LoggingLevel;
            var level = (LogEventLevel)levelId;

            var message = logInfo.Message;

            if (!string.IsNullOrEmpty(logInfo.Code))
            {
                message = $"{logInfo.Code} - {message}";
            }
            else if (!string.IsNullOrEmpty(acronym))
            {
                message = $"{acronym} - {message}";
            }


            WriteLog(level, message, logInfo.Exception, logInfo.InformationData, logInfo.Code);
        }


        private void WriteLog(LogEventLevel logEventLevel, string message, Exception exception = null, object data = null, string code = null)
        {
            using (LogContext.PushProperty("InformationData", JsonConvert.SerializeObject(data)))
            {
                var content = (data is string) ? data.ToString() : JsonConvert.SerializeObject(data);

                _logger.Log(logLevel: (LogLevel)logEventLevel, message: message, args: content, exception: exception);
            }
        }
    }
}

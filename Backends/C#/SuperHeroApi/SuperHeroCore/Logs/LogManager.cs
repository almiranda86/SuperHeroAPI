using SuperHeroCore.Enums;
using SuperHeroCore.Issuer.Behavior;
using SuperHeroCore.Logs.Behavior;
using SuperHeroCore.Logs.Enums;
using SuperHeroCore.Logs.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroCore.Logs
{
    public class LogManager : ILogManager
    {
        readonly IIssuer _issuer;
        readonly ILogService _logService;

        public LogManager(IIssuer issuer, ILogService logService)
        {
            _issuer = issuer;
            _logService = logService;
        }

        public void AddError(Issues issue, string message, Exception ex = null, object informationData = null)
        {
            LogServiceWrite(ILoggingLevel.Error, message, informationData, issue, ex);
        }

        public void AddInformation(string message, object informationData = null)
        {
            LogServiceWrite(ILoggingLevel.Information, message, informationData);
        }

        public void AddTrace(string message, object informationData = null)
        {
            LogServiceWrite(ILoggingLevel.Trace, message, informationData);
        }

        public void AddWarning(Issues issue, string message, Exception ex = null, object informationData = null)
        {
            LogServiceWrite(ILoggingLevel.Warning, message, informationData, issue, ex);
        }

        private void LogServiceWrite(ILoggingLevel loggingLevel, string message, object informationData = null, Issues issue = Issues.None, Exception ex = null)
        {
            try
            {
                _logService.Write(new LogInfo
                {
                    LoggingLevel = loggingLevel,
                    Code = issue != Issues.None ? _issuer.MakerProtocol(issue) : null,
                    Message = message,
                    Exception = ex,
                    InformationData = informationData
                }, _issuer.Prefix);
            }
            catch (Exception e)
            {
                _logService.Write(new LogInfo
                {
                    LoggingLevel = loggingLevel,
                    Code = _issuer.MakerProtocol(Issues.GeneralError501),
                    Message = message,
                    Exception = e,
                    InformationData = informationData
                }, _issuer.Prefix);
            }
        }

        public void AddProcessLog(ProcessLog processLog)
        {
            processLog.Service = _issuer.Prefix;
            _logService.WriteProcessLog(processLog);
        }
    }
}

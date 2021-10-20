using SuperHeroCore.Logs.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroCore.Logs.Model
{
    public class LogInfo
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public object InformationData { get; set; }
        public Exception Exception { get; set; }
        public ILoggingLevel LoggingLevel { get; set; }

        public LogInfo()
        {
            LoggingLevel = ILoggingLevel.Information;
        }
    }
}

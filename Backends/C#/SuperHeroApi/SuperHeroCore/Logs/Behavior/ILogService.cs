using SuperHeroCore.Logs.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroCore.Logs.Behavior
{
    public interface ILogService
    {
        void Write(IList<LogInfo> logInfos, string acronym = "");
        void Write(LogInfo logInfo, string acronym = "");
        void LogInfo(string message, object data = null);
        void LogWarning(string message, Exception exception = null, object data = null);
        void LogError(string message, Exception exception = null, object data = null);
    }
}

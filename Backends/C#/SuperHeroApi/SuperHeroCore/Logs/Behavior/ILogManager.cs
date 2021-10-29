using SuperHeroCore.Enums;
using SuperHeroCore.Logs.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroCore.Logs.Behavior
{
    public interface ILogManager
    {
        void AddTrace(string message, object informationData = null);
        void AddInformation(string message, object informationData = null);
        void AddWarning(Issues issue, string message, Exception ex = null, object informationData = null);
        void AddError(Issues issue, string message, Exception ex = null, object informationData = null);
        void AddProcessLog(ProcessLog processLog);
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroCore.Logs.Constants
{
    public static class LogTexts
    {

        public static string BegginingExecution(string feature, DateTime executionDate)
        {
            return $"Beggining execution of {feature} at {executionDate}";
        }

        public static string EndingExecution(string feature, DateTime executionDate)
        {
            return $"Ending execution of {feature} at {executionDate}";
        }

        public static string ListaAllHeroesPaginatedExecution(string feature, DateTime executionDate, int pageFrom, int pageSize)
        {
            return $"Executing {feature} - Selecting Heroes from {pageFrom} to {pageSize} at {executionDate} ";
        }

        public static string ListaAllHeroesPaginatedComplete(string feature, DateTime executionDate, int? heroes)
        {
            return $"{feature} executed - Total heroes founded {heroes} at {executionDate} ";
        }
    }
}

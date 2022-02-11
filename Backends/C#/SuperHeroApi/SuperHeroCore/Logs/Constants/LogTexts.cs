using System;

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

        public static string ExecutionFeature(string feature, DateTime executionDate)
        {
            return $"Executing {feature} - Selecting all Heroes at {executionDate}.";
        }

        public static string EndingExecutionFeature(string feature, DateTime executionDate, int? heroes)
        {
            return $"{feature} executed - Total heroes founded {heroes} at {executionDate} ";
        }

        public static string ErrorWhenCreatingHero(string feature, DateTime executionDate, string ex)
        {
            return $"Error while executin {feature} at {executionDate}. Ex: {ex}";
        }

        public static string ErrorWhenGettingCompleteHero(string feature, DateTime executionDate, string heroId, string ex)
        {
            return $"Error while executin {feature} looking for Public Hero Id {heroId} at {executionDate}. Ex: {ex}";
        }
    }
}

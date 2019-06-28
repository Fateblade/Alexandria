using ACI.Base.Logging;
using Prism.Logging;
using System;
using System.Collections.Generic;

namespace Alexandrian.Base.Logging
{
    public class MultiLogger : ILoggerFacade
    {
        private List<ILogger> _loggerList;

        public MultiLogger()
        {
            _loggerList = new List<ILogger>();
        }

        public void Log(string message, Prism.Logging.Category category, Prism.Logging.Priority priority)
        {
            _loggerList.ForEach(t => t.Log(message, transform(category), transform(priority)));
        }

        public void AddLogger(ILogger logger)
        {
            if(logger == null) { throw new ArgumentNullException("logger", "argument may not be null"); }
            _loggerList.Add(logger);
        }

        public void RemoveLogger(ILogger logger)
        {
            if (logger == null) { throw new ArgumentNullException("logger", "argument may not be null"); }
            _loggerList.Remove(logger);
        }

        private ACI.Base.Logging.Category transform(Prism.Logging.Category category)
        {
            return category == Prism.Logging.Category.Info ? ACI.Base.Logging.Category.Message :
                category == Prism.Logging.Category.Debug ? ACI.Base.Logging.Category.Debug :
                category == Prism.Logging.Category.Warn ? ACI.Base.Logging.Category.Warn :
                ACI.Base.Logging.Category.Exception;
        }

        private ACI.Base.Logging.Priority transform(Prism.Logging.Priority priority)
        {
            return priority == Prism.Logging.Priority.None ? ACI.Base.Logging.Priority.None :
                priority == Prism.Logging.Priority.Low ? ACI.Base.Logging.Priority.Low :
                priority == Prism.Logging.Priority.Medium ? ACI.Base.Logging.Priority.Medium :
                ACI.Base.Logging.Priority.High;
        }
    }
}

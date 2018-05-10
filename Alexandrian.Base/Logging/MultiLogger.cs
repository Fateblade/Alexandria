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

        private Category transform(Prism.Logging.Category category)
        {
            return category == Prism.Logging.Category.Info ? Category.Message :
                category == Prism.Logging.Category.Debug ? Category.Debug :
                category == Prism.Logging.Category.Warn ? Category.Warn :
                Category.Exception;
        }

        private Priority transform(Prism.Logging.Priority priority)
        {
            return priority == Prism.Logging.Priority.None ? Priority.None :
                priority == Prism.Logging.Priority.Low ? Priority.Low :
                priority == Prism.Logging.Priority.Medium ? Priority.Medium :
                Priority.High;
        }
    }
}

using System.Diagnostics;

namespace Alexandrian.Base.Logging
{
    public class DebugLogger : ILogger
    {
        public bool IsEnabled { get; set; }

        public DebugLogger()
        {
            IsEnabled = Debugger.IsAttached;
        }

        public void Log(string message, Category category, Priority priority)
        {
            if (IsEnabled)
            {
                Debugger.Log((int)priority, category.ToString(), message);
            }
        }
    }
}

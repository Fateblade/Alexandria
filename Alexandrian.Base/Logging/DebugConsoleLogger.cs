using System.Diagnostics;

namespace Alexandrian.Base.Logging
{
    public class DebugConsoleLogger : ILogger
    {
        public bool IsEnabled { get; set; }

        public DebugConsoleLogger()
        {
            IsEnabled = Debugger.IsAttached;
        }

        public void Log(string message, Category category, Priority priority)
        {
            if (IsEnabled)
            {
                Debug.WriteLine($"[{category.ToString()}][{priority.ToString()}]{message}");
            }
        }
    }
}

namespace Alexandrian.Base.Logging
{
    public enum Category { Message , Debug, Warn, Exception };
    public enum Priority { None, Low, Medium, High };

    public interface ILogger
    {
        bool IsEnabled { get; set; }
        void Log(string message, Category category, Priority priority);
    }
}

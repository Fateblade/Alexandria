using Fateblade.Alexandria.UI.WPF.Modules.LogBook.Views;

namespace Fateblade.Alexandria.UI.WPF.Modules.LogBook.Messages;

public class OpenLogbookMessage
{
    public Logbook LogbookToOpen { get; }

    public OpenLogbookMessage(Logbook logbookToOpen)
    {
        LogbookToOpen = logbookToOpen;
    }
}
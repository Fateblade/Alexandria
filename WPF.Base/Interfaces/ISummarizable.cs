using System;

namespace Fateblade.Alexandria.UI.WPF.Base.Interfaces
{
    public interface ISummarizable
    {
        Guid ID { get; }
        string Description { get; }
        string Summary { get; }
    }
}

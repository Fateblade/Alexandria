using System;

namespace Alexandrian.Base.Interfaces
{
    public interface ISummarizable
    {
        Guid ID { get; }
        string Description { get; }
        string Summary { get; }
    }
}

using System;

namespace Fateblade.Alexandria.UI.WPF.Models.Interfaces
{
    public interface IRelatable
    {
        Guid ID { get; }
        string Name { get; }
        int RelationCategoryID { get; }
    }
}

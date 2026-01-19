using System;

namespace Fateblade.Alexandria.UI.WPF.Base.Interfaces
{
    public interface IRelatable
    {
        Guid Id { get; }
        string Name { get; }
        int RelationCategoryId { get; }
    }
}

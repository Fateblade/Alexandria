using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement.Contract
{
    public interface ITagManager
    {
        IQueryable<Tag> GetAll();
        IQueryable<Tag> GetTagsAssociatedWithObject(Guid objectId);
        Tag Get(Guid tagId);

        void Update(Tag tag);
        void Remove(Tag tag);
        void Add(Tag tag);
    }
}

using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
{
    public interface ITagManager
    {
        IQueryable<Tag> GetAll();
        IQueryable<Tag> GetTagsAssociatedWithObject(Guid objectId);
        Tag Get(Guid tagId);

        void Update(Tag tag);
        void Delete(Tag tag);
        void Add(Tag tag);
    }
}

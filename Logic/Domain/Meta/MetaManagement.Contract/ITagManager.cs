using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract.Exceptions;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
{
    [MapException(typeof(MetaManagementException))]
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

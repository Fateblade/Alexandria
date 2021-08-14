using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
{
    public interface ILinkManager
    {
        IQueryable<Link> GetAll();
        IQueryable<Link> GetAllAssociatedWith(Guid objectId);
        Link Get(Guid linkId);

        void Update(Link link);
        void Delete(Link link);
        void Add(Link link);
    }
}

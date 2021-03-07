using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement.Contract
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

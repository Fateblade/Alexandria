using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract.Exceptions;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
{
    [MapException(typeof(MetaManagementException))]
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

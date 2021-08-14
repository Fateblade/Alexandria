using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract.Exceptions;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
{
    [MapException(typeof(MetaManagementException))]
    public interface ITextInfoManager
    {
        IQueryable<TextInfo> GetAll();
        IQueryable<TextInfo> GetTextInfosAssociatedWithObject(Guid objectId);
        TextInfo Get(Guid textInfoId);

        void Update(TextInfo textInfo);
        void Delete(TextInfo textInfo);
        void Add(TextInfo textInfo);
    }
}

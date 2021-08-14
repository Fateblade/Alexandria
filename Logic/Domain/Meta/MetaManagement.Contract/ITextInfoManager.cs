using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
{
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

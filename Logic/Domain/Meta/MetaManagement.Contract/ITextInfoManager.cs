using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement.Contract
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

using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Components.Data.GenericDataStoring.Contract;
using System;
using System.Linq;
using Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement
{
    internal class TextInfoManager : ITextInfoManager
    {
        private readonly IGenericRepository<TextInfo> _repository;



        public TextInfoManager(IGenericRepository<TextInfo> repository)
        {
            _repository = repository;
        }



        public IQueryable<TextInfo> GetAll()
        {
            return _repository.Query;
        }

        public IQueryable<TextInfo> GetTextInfosAssociatedWithObject(Guid objectId)
        {
            return _repository.Query.Where(t => t.AssociatedObject == objectId);
        }

        public TextInfo Get(Guid textInfoId)
        {
            return _repository.Query.First(t => t.Id == textInfoId);
        }

        public void Update(TextInfo textInfo)
        {
            _repository.Update(textInfo);
        }

        public void Delete(TextInfo textInfo)
        {
            _repository.Delete(textInfo);
        }

        public void Add(TextInfo textInfo)
        {
            _repository.Add(textInfo);
        }
    }
}

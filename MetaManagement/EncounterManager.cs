using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Domain.MetaManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement
{
    internal class EncounterManager :  IEncounterManager
    {
        private readonly IGenericRepository<Encounter> _repository;
        private readonly ISessionManager _sessionManager;
        private readonly IStageManager _stageManager;


        public EncounterManager(IGenericRepository<Encounter> repository, ISessionManager sessionManager, IStageManager stageManager)
        {
            _repository = repository;
            _sessionManager = sessionManager;
            _stageManager = stageManager;
        }



        public IQueryable<Encounter> GetAll()
        {
            return _repository.Query;
        }

        public IQueryable<Encounter> GetEncountersOfSession(Guid sessionId)
        {
            Session session = _sessionManager.Get(sessionId);

            return _repository.Query.Where(t => session.PlayedEncounterIds.Contains(t.Id));
        }

        public IQueryable<Encounter> GetEncountersOfStage(Guid stageId)
        {
            Stage stage = _stageManager.Get(stageId);

            return _repository.Query.Where(t => stage.EncounterIds.Contains(t.Id));
        }

        public Encounter Get(Guid encounterId)
        {
            return _repository.Query.First(t => t.Id == encounterId);
        }

        public void Update(Encounter encounter)
        {
            _repository.Update(encounter);
        }

        public void Delete(Encounter encounter)
        {
            _repository.Delete(encounter);
        }

        public void Add(Encounter encounter)
        {
            _repository.Add(encounter);
        }
    }
}

using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Domain.MetaManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement
{
    internal class StageManager : IStageManager
    {
        private readonly IGenericRepository<Stage> _repository;
        private readonly ISessionManager _sessionManager;
        private readonly IAdventureManager _adventureManager;



        public StageManager(IGenericRepository<Stage> repository, ISessionManager sessionManager, IAdventureManager adventureManager)
        {
            _repository = repository;
            _sessionManager = sessionManager;
            _adventureManager = adventureManager;
        }



        public IQueryable<Stage> GetAll()
        {
            return _repository.Query;
        }

        public IQueryable<Stage> GetStagesOfSession(Guid sessionId)
        {
            Session session = _sessionManager.Get(sessionId);

            return _repository.Query.Where(t => session.PlayedStageIds.Contains(t.Id));
        }

        public IQueryable<Stage> GetStagesOfAdventure(Guid adventureId)
        {
            Adventure adventure = _adventureManager.Get(adventureId);

            return _repository.Query.Where(t => adventure.StageIds.Contains(t.Id));
        }

        public Stage Get(Guid stageId)
        {
            return _repository.Query.First(t => t.Id == stageId);
        }

        public void Update(Stage stage)
        {
            _repository.Update(stage);
        }

        public void Delete(Stage stage)
        {
            _repository.Delete(stage);
        }

        public void Add(Stage stage)
        {
            _repository.Add(stage);
        }
    }
}

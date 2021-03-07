using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement.Contract
{
    public interface IStageManager
    {
        IQueryable<Stage> GetAll();
        IQueryable<Stage> GetStagesOfSession(Guid sessionId);
        IQueryable<Stage> GetStagesOfAdventure(Guid adventureId);
        Stage Get(Guid stageId);

        void Update(Stage stage);
        void Delete(Stage stage);
        void Add(Stage stage);
    }
}

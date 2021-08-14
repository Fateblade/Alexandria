using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
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

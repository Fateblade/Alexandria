using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract.Exceptions;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
{
    [MapException(typeof(MetaManagementException))]
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

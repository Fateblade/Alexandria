using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract.Exceptions;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
{
    [MapException(typeof(MetaManagementException))]
    public interface IEncounterManager
    {
        IQueryable<Encounter> GetAll();
        IQueryable<Encounter> GetEncountersOfSession(Guid sessionId);
        IQueryable<Encounter> GetEncountersOfStage(Guid stageId);
        Encounter Get(Guid encounterId);

        void Update(Encounter encounter);
        void Delete(Encounter encounter);
        void Add(Encounter encounter);
    }
}

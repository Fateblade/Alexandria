using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
{
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

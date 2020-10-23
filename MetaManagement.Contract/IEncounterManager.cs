using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement.Contract
{
    public interface IEncounterManager
    {
        IQueryable<Encounter> GetAll();
        IQueryable<Encounter> GetEncountersOfSession(Guid sessionId);
        IQueryable<Encounter> GetEncountersOfStage(Guid stageId);
        Encounter Get(Guid encounterId);

        void Update(Encounter encounter);
        void Remove(Encounter encounter);
        void Add(Encounter encounter);
    }
}

﻿using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;
using System;
using System.Collections.Generic;

namespace Fateblade.Alexandria.CrossCutting.Meta.DataClasses
{
    public enum EncounterType { Fight, Social, Exploration, Other }
    public enum EncounterState { Success, Failure, Unexplored, NeutralOutcome }

    public class Encounter : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public EncounterType Type { get; set; }
        public List<Guid> ParticipatingMonsterIds { get; set; } = new List<Guid>();
        public List<Guid> ParticipatingNpcIds { get; set; } = new List<Guid>();
        public string Description { get; set; }
        public string Summary { get; set; }
        public Guid RewardId { get; set; }
        public string ConsequenceSuccess { get; set; }
        public string ConsequenceFailure { get; set; }
        public EncounterState State { get; set; }
    }
}

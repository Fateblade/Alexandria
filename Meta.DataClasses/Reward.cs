using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;
using System;

namespace Fateblade.Alexandria.CrossCutting.Meta.DataClasses
{
    public class Reward : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public string RewardInformation { get; set; }
        public bool Received { get; set; }
    }
}

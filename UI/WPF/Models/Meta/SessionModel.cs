using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;
using Fateblade.Alexandria.UI.WPF.Models.Entities;
using System;
using System.Collections.Generic;

namespace Fateblade.Alexandria.UI.WPF.Models.Meta
{
    public class SessionModel : ModifiableDataClassModel<Session>
    {
        public string Summary { get; set; }
        public string Title { get; set; }
        public DateTime PlayDate { get; set; }
        public List<PlayerCharacterModel> ParticipatingCharacters { get; set; } = new List<PlayerCharacterModel>();
        public List<AdventureModel> PlayedAdventures { get; set; } = new List<AdventureModel>();
        public List<StageModel> PlayedStages { get; set; } = new List<StageModel>();
        public List<EncounterModel> PlayedEncounters { get; set; } = new List<EncounterModel>();

        public override Session ModifiedEntity => throw new NotImplementedException();

        public SessionModel(Session original) : base(original)
        {
        }

        public override void ModifyOriginalEntity()
        {
            throw new NotImplementedException();
        }
    }
}

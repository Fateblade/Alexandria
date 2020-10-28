using Fateblade.Alexandria.CrossCutting.Environment.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;
using Fateblade.Alexandria.UI.WPF.Models.Entities;
using System;
using System.Collections.Generic;

namespace Fateblade.Alexandria.UI.WPF.Models.Environment
{
    public class WorldModel : ModifiableDataClassModel<World>
    {
        public string Name;
        public string Summary;
        public string Timeline;
        public Guid TrackerId;
        public List<PlaneModel> Planes { get; set; } = new List<PlaneModel>();
        public List<PantheonModel> Pantheons { get; set; } = new List<PantheonModel>();
        public List<NonPlayerCharacterModel> Npcs { get; set; } = new List<NonPlayerCharacterModel>();
        public List<MonsterModel> Monsters { get; set; } = new List<MonsterModel>();
        public List<FactionModel> Factions { get; set; } = new List<FactionModel>();
        public List<GroupModel> Groups { get; set; } = new List<GroupModel>();
        public List<PlayerCharacterModel> Characters { get; set; } = new List<PlayerCharacterModel>();
        public List<DeityModel> NonPantheonDeities { get; set; } = new List<DeityModel>();

        public WorldModel(World original) : base(original)
        {
        }
    }
}
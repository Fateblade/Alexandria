using System;
using System.Collections.Generic;

namespace Fateblade.Alexandria.CrossCutting.Environment.DataClasses
{
    public class World
    {
        public string Name;
        public string Summary;
        public string Timeline;
        public Guid TrackerID;
        public List<Guid> Planes;
        public List<Guid> Pantheons;
        public List<Guid> Npcs;
        public List<Guid> Monsters;
        public List<Guid> Factions;
        public List<Guid> Groups;
    }
}

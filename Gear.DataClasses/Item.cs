﻿namespace Fateblade.Alexandria.CrossCutting.Gear.DataClasses
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Statistics { get; set; }
        public int RelationCategoryID { get; }
    }
}

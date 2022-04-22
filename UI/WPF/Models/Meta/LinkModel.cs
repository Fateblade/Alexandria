﻿using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;

namespace Fateblade.Alexandria.UI.WPF.Models.Meta
{
    public class LinkModel : ModifiableDataClassModel<Link>
    {
        public IIdentifiableGuidEntity AssociatedObject { get; set; }
        public LinkType Type { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }

        public override Link ModifiedEntity => throw new System.NotImplementedException();

        public LinkModel(Link original) : base(original)
        {
        }

        public override void ModifyOriginalEntity()
        {
            throw new System.NotImplementedException();
        }
    }
}

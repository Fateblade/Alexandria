﻿using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;

namespace Fateblade.Alexandria.UI.WPF.Models.Entities
{
    public class AmbitionModel : ModifiableDataClassModel<Ambition>
    {
        public string ShortInfo { get; set; }
        public string LongInfo { get; set; }

        public AmbitionModel(Ambition original) : base(original)
        {
        }
    }
}
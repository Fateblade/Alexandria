using System;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;

namespace Fateblade.Alexandria.UI.WPF.Models.Base
{
    public abstract class ModifiableDataClassModel<TEntity> : Prism.Mvvm.BindableBase where TEntity : IIdentifiableGuidEntity
    {
        private Guid _id;



        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public virtual TEntity OriginalEntity { get; }

        protected ModifiableDataClassModel(TEntity original)
        {
            OriginalEntity = original;
            Id = original?.Id ?? Guid.Empty;
        }
    }
}

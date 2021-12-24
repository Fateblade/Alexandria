using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;
using System;

namespace Fateblade.Alexandria.UI.WPF.Base
{
    public abstract class ModifiableDataClassModel<TEntity> : Prism.Mvvm.BindableBase where TEntity : IIdentifiableGuidEntity
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            private set => SetProperty(ref _id, value);
        }

        public virtual TEntity OriginalEntity { get; }
        /// <summary>
        /// returns a new entity with the modified values of the original
        /// </summary>
        public abstract TEntity ModifiedEntity { get; }

        protected ModifiableDataClassModel(TEntity original)
        {
            OriginalEntity = original;
            Id = original?.Id ?? Guid.Empty;
        }

        /// <summary>
        /// applies the changes to the original entity with the applied modifications
        /// </summary>
        /// <returns></returns>
        public abstract void ModifyOriginalEntity();
    }
}

using System;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;

namespace Fateblade.Alexandria.UI.WPF.Base
{
    public abstract class ModifiableIdentifiableDataClassModel<TEntity> : ModifiableDataClassModel<TEntity> where TEntity : IIdentifiableGuidEntity
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            private set => SetProperty(ref _id, value);
        }
        
        protected ModifiableIdentifiableDataClassModel(TEntity original)
            :base(original)
        {
            Id = original?.Id ?? Guid.Empty;
        }
    }

    public abstract class ModifiableDataClassModel<TEntity> : Prism.Mvvm.BindableBase
    {
        public virtual TEntity OriginalEntity { get; }
        /// <summary>
        /// returns a new entity with the modified values of the original
        /// </summary>
        public abstract TEntity ModifiedEntity { get; }

        protected ModifiableDataClassModel(TEntity original)
        {
            OriginalEntity = original;
        }

        /// <summary>
        /// applies the changes to the original entity with the applied modifications
        /// </summary>
        /// <returns></returns>
        public abstract void ModifyOriginalEntity();
    }
}

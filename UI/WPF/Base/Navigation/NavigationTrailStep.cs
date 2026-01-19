using System;

namespace Fateblade.Alexandria.UI.WPF.Base.Navigation
{
    public class NavigationTrailStep
    {
        public Guid Id { get; set; }
        public ITrailableView TrailableView { get; set; }
    }
}

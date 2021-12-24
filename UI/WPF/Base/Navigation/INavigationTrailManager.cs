using System;

namespace Fateblade.Alexandria.UI.WPF.Base.Navigation
{
    public interface INavigationTrailManager
    {
        void ContinueTrail(ITrailableView nextView);
        void TrailBack(Guid trailStepId, bool forceClose);
        void StartNewTrail(ITrailableView firstView, bool forceClose);
    }
}

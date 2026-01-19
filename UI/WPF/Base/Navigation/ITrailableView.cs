using Prism.Mvvm;

namespace Fateblade.Alexandria.UI.WPF.Base.Navigation
{
    public interface ITrailableView
    {
        /// <summary>
        /// Name to be displayed in the navigation trail
        /// </summary>
        string TrailDisplayName { get; }
        /// <summary>
        /// is called if the user returns to this view
        /// </summary>
        void TrailReturned();
        /// <summary>
        /// checks if any unsaved changes or other important information is in a state where it could be lost
        /// </summary>
        /// <returns>returns true if view can be closed without further user input</returns>
        bool CanBeClosedWithoutUserInput();
        BindableBase GetView();
    }
}

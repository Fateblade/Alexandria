using Prism.Ioc;

namespace Fateblade.Alexandria.UI.WPF.Base.Interfaces
{
    public interface IContainerApp
    {
        IContainerProvider Container { get; }
    }
}

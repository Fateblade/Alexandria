using Alexandrian.Base.Interfaces;

namespace Alexandrian.Base.Models
{
    public enum ConnectionStatus { Undefined, Active, Inactive, Destroyed };
    public enum ConnectionType { Undefined, OneWayToSource, OneWayToTarget, TwoWay };

    public class Connection : BaseObject
    {
        private ConnectionStatus _Status;
        public ConnectionStatus Status
        {
            get { return _Status; }
            set { SetProperty(ref _Status, value); }
        }

        private ConnectionType _Type;
        public ConnectionType Type
        {
            get { return _Type; }
            set { SetProperty(ref _Type, value); }
        }

        private IConnectable _Source;
        public IConnectable Source
        {
            get { return _Source; }
            set { SetProperty(ref _Source, value); }
        }

        private IConnectable _Target;
        public IConnectable Target
        {
            get { return _Target; }
            set { SetProperty(ref _Target, value); }
        }
    }
}

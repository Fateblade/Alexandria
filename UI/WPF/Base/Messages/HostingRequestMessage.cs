using System;

namespace Fateblade.Alexandria.UI.WPF.Base.Messages
{
    public class HostingRequestMessage
    {
        public Type VmToHost { get; }
        public string HostName { get; }

        public HostingRequestMessage(Type vmToHost, string hostName)
        {
            VmToHost = vmToHost;
            HostName = hostName;
        }
    }
}

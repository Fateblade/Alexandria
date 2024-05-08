﻿using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Fateblade.Alexandria.UI.WPF.Base.Messages;
using Prism.Ioc;
using Prism.Mvvm;
using System;

namespace Fateblade.Alexandria.UI.WPF.Base.Views
{
    public abstract class HostingViewModelBase : BindableBase
    {
        private readonly IEventBroker _eventBroker;
        private readonly IContainerProvider _container;
        private readonly string _hostName;
        private Type _currentlyHostedVmType;



        private BindableBase _displayedContent;
        public BindableBase DisplayedContent
        {
            get => _displayedContent;
            private set => SetProperty(ref _displayedContent, value);
        }



        protected HostingViewModelBase(IEventBroker eventBroker, IContainerProvider container, string hostName)
        {
            _eventBroker = eventBroker;
            _container = container;
            _hostName = hostName;

            _eventBroker.Subscribe<HostingRequestMessage>(handleHostingRequestMessage);
        }

        /// <summary>
        /// Resolves a instance of the type or tries to delegate instanciation down the line of generic nested views that inherit from <see cref="HostingViewModelBase" />
        /// </summary>
        /// <param name="vmType">type has to inherit from <see cref="BindableBase" /></param>
        protected void hostOrDelegateHosting(Type vmType)
        {
            if (!vmType.IsSubclassOf(typeof(BindableBase))) throw new ArgumentException("type does not derive from BindableBase");

            if (_currentlyHostedVmType is { IsGenericType: true } && vmType.IsGenericType
                && _currentlyHostedVmType.IsSubclassOf(typeof(HostingViewModelBase))
                && vmType.IsSubclassOf(typeof(HostingViewModelBase)))
            {
                if (vmType.BaseType == _currentlyHostedVmType.BaseType
                    && vmType.BaseType!=null)
                {
                    _currentlyHostedVmType = vmType;
                    _eventBroker.Raise(
                        new HostingRequestMessage(
                            vmType.GenericTypeArguments[0],
                            vmType.BaseType.Name));
                }
            }

            _currentlyHostedVmType = vmType;
            DisplayedContent = (BindableBase)_container.Resolve(vmType);
        }

        protected void hostDirectly(BindableBase vmWithExistingData)
        {
            _currentlyHostedVmType = vmWithExistingData.GetType();
            DisplayedContent = vmWithExistingData;
        }


        private void handleHostingRequestMessage(HostingRequestMessage obj)
        {
            if (obj.HostName == _hostName)
            {
                hostOrDelegateHosting(obj.VmToHost);
            }
        }

    }
}
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Unity;

namespace SM.Core.Framework.Unity
{
    /// <summary>
    /// TODO:Need to write detial information
    /// </summary>
    public class UnityServiceBehavior : IServiceBehavior
    {
        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>
        private ServiceHost _serviceHost = null;

        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>
        private readonly UnityInstanceProvider _instanceProvider;

        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>
        /// <param name="container"></param>
        public UnityServiceBehavior(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this._instanceProvider = new UnityInstanceProvider(container);
        }

        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase,
                                         Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        { }

        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            if (serviceDescription == null)
            {
                throw new ArgumentNullException("serviceDescription");
            }

            if (serviceHostBase == null)
            {
                throw new ArgumentNullException("serviceHostBase");
            }

            var dispatchers = serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>();

            foreach (ChannelDispatcher dispatcher in dispatchers)
            {
                foreach (EndpointDispatcher ed in dispatcher.Endpoints)
                {
                    this._instanceProvider.ServiceType = serviceDescription.ServiceType;
                    ed.DispatchRuntime.InstanceProvider = this._instanceProvider;
                }
            }
        }

        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        { }

        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>
        public void AddToHost(ServiceHost host)
        {
            if (host == null)
            {
                throw new ArgumentNullException("host");
            }

            if (this._serviceHost != null)
            {
                return;
            }

            host.Description.Behaviors.Add(this);
            this._serviceHost = host;
        }
    }
}
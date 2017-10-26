using System;
using System.ServiceModel;
using Unity;

namespace SM.Core.Framework.Unity
{
    public class UnityServiceHost : ServiceHost
    {
        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>
        private readonly IUnityContainer _container;

        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>
        public UnityServiceHost(IUnityContainer container, Type serviceType, Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this._container = container;
        }

        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>
        protected override void OnOpening()
        {
            UnityServiceBehavior usb = new UnityServiceBehavior(this._container);

            usb.AddToHost(this);

            base.OnOpening();
        }
    }
}
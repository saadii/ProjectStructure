using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Unity;

namespace SM.Core.Framework.Unity
{
    /// <summary>
    ///
    /// </summary>
    public abstract class UnityServiceHostFactoryBase : ServiceHostFactory, IDisposable
    {
        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>
        private readonly IUnityContainer _container;

        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>
        protected UnityServiceHostFactoryBase()
        {
            IUnityContainer preConfiguredRuntimeConfigurations = this.LoadConfigurations();

            this._container = UnityHelper.InitializeUnityContainer(preConfiguredRuntimeConfigurations);
        }

        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._container != null)
                {
                    this._container.Dispose();
                }
            }
        }

        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>
        protected abstract IUnityContainer LoadConfigurations();

        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new UnityServiceHost(this._container, serviceType, baseAddresses);
        }
    }
}
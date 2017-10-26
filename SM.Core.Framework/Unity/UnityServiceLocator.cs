using CommonServiceLocator;
using System;
using System.Collections.Generic;
using Unity;

namespace SM.Core.Framework.Unity
{
    /// <summary>
    /// Unity service locator that initializes the container.
    /// </summary>
    public class UnityServiceLocator : ServiceLocatorImplBase, IDisposable
    {
        /// <summary>
        /// Container congfigurations.
        /// </summary>
        private IUnityContainer _container;

        /// <summary>
        /// To detect redundant calls
        /// </summary>
        private bool _disposed = false;

        /// <summary>
        /// Creates unity service locator with container initialized based on given preconfigured
        /// runtime configurations and overrides them with possible configurations from configuration file.
        /// </summary>
        /// <param name="preconfiguredContainer">Preconfigured runtime configurations.</param>
        public UnityServiceLocator(IUnityContainer preconfiguredContainer)
        {
            this.ConfigureContainer(preconfiguredContainer);
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~UnityServiceLocator()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Returns the fully configured Unity IoC container.
        /// </summary>
        /// <returns>Configured Unity IoC container.</returns>
        public IUnityContainer GetConfiguredContainer()
        {
            return this._container;
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposable pattern implementation.
        /// </summary>
        /// <param name="disposing">Disposing switch to releas managed / unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    if (this._container != null)
                    {
                        this._container.Dispose();
                        this._container = null;
                    }
                }

                this._disposed = true;
            }
        }

        /// <summary>
        /// Gets the configured instances based on the given service type.
        /// </summary>
        /// <param name="serviceType">Type for which configured intances are retrieved.</param>
        /// <returns>Configured instances for the type.</returns>

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return this._container.ResolveAll(serviceType);
        }

        /// <summary>
        /// Gets the configured instance based on the given service type and key.
        /// </summary>
        /// <param name="serviceType">Type for which configured intance is retrieved.</param>
        /// <param name="key">Specific configuration key for the configured instance.</param>
        /// <returns>Configured instance for the type.</returns>

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return this._container.Resolve(serviceType, key);
        }

        /// <summary>
        /// Configures the Unity container with the given preconfigured values and then reads configurations from the
        /// configuration file. Configuration file is used only for overriding the runtime configurations.
        /// </summary>
        /// <param name="preConfiguredContainer">Preconfigured runtime configurations.</param>

        private void ConfigureContainer(IUnityContainer preConfiguredContainer)
        {
            if (preConfiguredContainer != null)
            {
                this._container = preConfiguredContainer;
            }
            else
            {
                this._container = new UnityContainer();
            }
        }
    }
}
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Unity;

namespace SM.Core.Framework.Unity
{
    public class UnityInstanceProvider : IInstanceProvider
    {
        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>
        private IUnityContainer _container;

        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>
        public UnityInstanceProvider(IUnityContainer unityContainer)
        {
            this._container = unityContainer;
        }

        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>
        public Type ServiceType { get; set; }

        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return this._container.Resolve(this.ServiceType);
        }

        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>

        public object GetInstance(InstanceContext instanceContext)
        {
            return this.GetInstance(instanceContext, null);
        }

        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            //this._container.Teardown(instance);
        }
    }
}
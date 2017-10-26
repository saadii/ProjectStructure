using System;
using System.Globalization;
using System.Web.Mvc;
using Unity;

namespace SM.Core.Framework.Unity
{
    /// <summary>
    /// UnityControllerFactory class for injecting Dependancy
    /// </summary>
    public class UnityControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// TODO:Need to write detial information
        /// </summary>
        private readonly IUnityContainer _container;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="container">Unity Container</param>
        public UnityControllerFactory(IUnityContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Resolves IController from UnityContainer by given controllertype
        /// </summary>
        /// <param name="requestContext">This represent the RequestContext</param>
        /// <param name="controllerType">This represent the controllerType</param>

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext,
            Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }

            if (!typeof(IController).IsAssignableFrom(controllerType))
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,
                    "Type requested is not a controller: {0}", controllerType.Name),
                    "controllerType");

            IController controller = _container.Resolve(controllerType) as IController;
            return controller;
        }
    }
}
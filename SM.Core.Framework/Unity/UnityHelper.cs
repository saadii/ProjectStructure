using CommonServiceLocator;
using Unity;

namespace SM.Core.Framework.Unity
{
    /// <summary>
    ///
    /// </summary>
    public static class UnityHelper
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static IUnityContainer InitializeUnityContainer()
        {
            return Initialize(null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="preconfiguredContainer"></param>
        /// <returns></returns>
        public static IUnityContainer InitializeUnityContainer(IUnityContainer preconfiguredContainer)
        {
            return Initialize(preconfiguredContainer);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="preconfiguredContainer"></param>
        /// <returns></returns>
        private static IUnityContainer Initialize(IUnityContainer preconfiguredContainer)
        {
            UnityServiceLocator locator = new UnityServiceLocator(preconfiguredContainer);

            ServiceLocator.SetLocatorProvider(() => locator);

            return locator.GetConfiguredContainer();
        }
    }
}
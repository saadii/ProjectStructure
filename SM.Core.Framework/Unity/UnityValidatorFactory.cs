using FluentValidation;
using System;
using Unity;

namespace SM.Core.Framework.Unity
{
    /// <summary>
    ///
    /// </summary>
    public class UnityValidatorFactory : ValidatorFactoryBase
    {
        /// <summary>
        ///
        /// </summary>
        private readonly IUnityContainer _container;

        /// <summary>
        ///
        /// </summary>
        /// <param name="container"></param>
        public UnityValidatorFactory(IUnityContainer container)
        {
            _container = container;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="validatorType"></param>
        /// <returns></returns>
        public override IValidator CreateInstance(Type validatorType)
        {
            return _container.Resolve(validatorType) as IValidator;
        }
    }
}
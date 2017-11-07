using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace SM.Core.Framework.Unity
{
    /// <summary>
    ///
    /// </summary>
    public static class UnityExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="container"></param>
        /// <param name="lifetimeManager"></param>
        public static void RegisterAutoMapperType(this IUnityContainer container, LifetimeManager lifetimeManager = null)
        {
            RegisterMappingProfilesFromAssembly(container);
            container.RegisterMapper();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="container"></param>
        public static void RegisterMappingProfilesFromAssembly(IUnityContainer container)
        {
            //IEnumerable<Type> autoMapperProfileTypes = AllClasses.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
            //               .Where(type => type != typeof(Profile) && typeof(Profile).IsAssignableFrom(type));

            //foreach (var type in autoMapperProfileTypes)
            //{
            //    RegisterMappingProfile(container, type);
            //}
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="container"></param>
        /// <param name="profileType"></param>
        /// <returns></returns>
        private static void RegisterMappingProfile(IUnityContainer container, Type profileType)
        {
            container.RegisterType(typeof(Profile), profileType, profileType.FullName, new ContainerControlledLifetimeManager());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private static IEnumerable<Type> GetAccessibleTypes(this Assembly assembly)
        {
            try
            {
                return assembly.DefinedTypes.Select(t => t.AsType());
            }
            catch (ReflectionTypeLoadException ex)
            {
                return ex.Types.Where(t => t != null);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="container"></param>
        public static void RegisterMapper(this IUnityContainer container)
        {
            //container.RegisterType<IConfigurationProvider>(new ContainerControlledLifetimeManager(), new InjectionFactory(c =>
            //{
            //    var configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            //    configuration.ConstructServicesUsing(t => container.Resolve(t));
            //    foreach (var profile in c.ResolveAll<Profile>())
            //        configuration.AddProfile(profile);
            //    return configuration;
            //}
            //));
            //container.RegisterType<IMappingEngine, MappingEngine>(new ContainerControlledLifetimeManager(), new InjectionConstructor(typeof(IConfigurationProvider)));
        }
    }
}
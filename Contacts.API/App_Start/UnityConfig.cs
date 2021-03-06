using AutoMapper;
using Contacts.API.DAL;
using System;
using Unity;

namespace Contacts.API
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container

        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;

        #endregion Unity Container

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IContactRepository, ContactRepository>(TypeLifetime.Singleton);
            container.RegisterType<IContactInteractor, ContactInteractor>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContactMappingProfile());
                cfg.ForAllMaps((obj, cnfg) => cnfg.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)));
            });

            container.RegisterInstance(config.CreateMapper());
        }
    }
}
﻿using Autofac;
using Autofac.Integration.Mvc;
using Business.DependencyInjection;
using Business.Identity;
using Business.Identity.Models;
using Business.Identity.Proxies;
using Business.Repository;
using Business.Services;
using Business.Services.Context;
using MedioClinic.Config;
using MedioClinic.Utils;
using Microsoft.Owin;
using System.Globalization;
using System.Web.Mvc;

namespace MedioClinic
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            // Initializes the Autofac builder instance
            var builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Adds a custom registration source (IRegistrationSource) that provides all services from the Kentico API
            builder.RegisterSource(new CmsRegistrationSource());

            // Registers all services that implement IService interface
            builder.RegisterAssemblyTypes(typeof(IService).Assembly)
                .Where(x => x.IsClass && !x.IsAbstract && typeof(IService).IsAssignableFrom(x))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            // Registers site context
            builder.RegisterType<SiteContextService>().As<ISiteContextService>()
                .WithParameter((parameter, context) => parameter.Name == "currentCulture",
                    (parameter, context) => CultureInfo.CurrentUICulture.Name)
                .WithParameter((parameter, context) => parameter.Name == "sitename",
                    (parameter, context) => AppConfig.Sitename)
                .InstancePerRequest();

            // Registers business dependencies
            builder.RegisterType<BusinessDependencies>().As<IBusinessDependencies>()
                .InstancePerRequest();

            // Registers all repositories that implement IRepository interface
            builder.RegisterAssemblyTypes(typeof(IRepository).Assembly)
                .Where(x => x.IsClass && !x.IsAbstract && typeof(IRepository).IsAssignableFrom(x))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.Register(context => new KenticoUserStore(context.Resolve<ISiteContextService>().SiteName))
                .As<IKenticoUserStore>()
                .InstancePerRequest();

            builder.RegisterType<MedioClinicUserStore>()
                .As<IMedioClinicUserStore>()
                .InstancePerRequest();

            builder.RegisterType<MedioClinicUserManager>()
                .As<IMedioClinicUserManager<MedioClinicUser, int>>()
                .InstancePerRequest();

            builder.Register(context =>
                {
                    context.TryResolve(out IOwinContext owinContext);

                    return new MedioClinicSignInManager(
                        context.Resolve<IMedioClinicUserManager<MedioClinicUser, int>>(),
                        owinContext?.Authentication ?? new OwinContext().Authentication);
                })
                .As<IMedioClinicSignInManager<MedioClinicUser, int>>()
                .InstancePerRequest();

            // Resolves the dependencies
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}
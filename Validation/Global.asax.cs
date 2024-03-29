﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using DataValidation.ModelBinders;
using DataValidation.Modules;
using FluentValidation.Mvc;

namespace Validation
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            FluentValidationModelValidatorProvider.Configure();
            RegisterIoCContainer();
        }

        private void RegisterIoCContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AutoMapperConfigurationModule>();
            builder.RegisterModule<RepositoryConfigurationModule>();
            builder.RegisterModule<ServiceModule>();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(new[] {Assembly.GetExecutingAssembly()});
            builder.RegisterModelBinderProvider();
            
            var container = builder.Build();
            
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
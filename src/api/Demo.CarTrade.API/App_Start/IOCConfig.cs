using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using Demo.CarTrade.Interfaces;
using Demo.CarTrade.Services.Client;
using System.Web.Http;
using Demo.CarTrade.Entity;
namespace Demo.CarTrade.API.App_Start
{
    public class IOCConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<BrandManagementServiceClient>().As<IBrandManagementService>();
            builder.RegisterType<CarManagementServiceClient>().As<ICarManagementService>();
            builder.RegisterInstance<ICarManagementService>(new CarManagementServiceClient("BasicHttpBinding_ICarManagementService"));
            builder.RegisterInstance<IBrandManagementService>(new BrandManagementServiceClient("BasicHttpBinding_IBrandManagementService"));
            var container = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}
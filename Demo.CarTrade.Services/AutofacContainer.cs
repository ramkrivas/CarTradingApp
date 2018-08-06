using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Integration.Wcf;
using Autofac;
using Demo.CarTrade.Interfaces;
using Demo.CarTrade.Entity;
using Demo.CarTrade.Repository;

namespace Demo.CarTrade.Services
{
    public class AutoFacContainerBuilder
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BrandManagementService>().AsSelf();
            builder.RegisterType<CarManagementService>().AsSelf();
            builder.RegisterType<CarTradeRepository<Brand>>().As<IRepository<Brand>>();
            builder.RegisterType<CarTradeRepository<Car>>().As<IRepository<Car>>();
           
            return builder.Build();

        }
    }
}
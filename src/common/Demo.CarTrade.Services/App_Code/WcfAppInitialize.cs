using Autofac.Integration.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.CarTrade.Services.App_Code
{
    public static class WcfAppInitialize
    {
        public static void AppInitialize()
        {
            var container = AutoFacContainerBuilder.BuildContainer();
            AutofacHostFactory.Container = container;


        }
    }
}
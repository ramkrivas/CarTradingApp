using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Autofac.Configuration;
using Autofac.Integration.Wcf;
namespace Demo.CarTrade.Services
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var container = AutoFacContainerBuilder.BuildContainer();
            AutofacHostFactory.Container = container;
        }

    }
}
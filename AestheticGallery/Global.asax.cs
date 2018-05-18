using BusinessLogicLayer.Infrastucure;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using NLayerApp.WEB.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AestheticGallery
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule photoInject = new PhotoInject();
            NinjectModule serviceModule = new ServiceInject("DefaultConnection");
            var kernel = new StandardKernel(photoInject, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}

using HyperSlackers.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HyperSlackers.Bootstrap.Demo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // use the convention-based model metadata provider
            ModelMetadataProviders.Current = new ConventionModelMetadataProvider(false, typeof(Localized.Models), typeof(Localized.Enums), typeof(Localized.Validation));
        }
    }
}

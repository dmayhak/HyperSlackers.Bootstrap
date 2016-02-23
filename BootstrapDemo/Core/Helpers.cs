using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Extensions;

namespace HyperSlackers.Bootstrap.Demo
{
    public class Helpers
    {
        public static bool IsProduction()
        {
            return (HttpContext.Current != null && !HttpContext.Current.IsDebuggingEnabled);
        }

        public static string GetBootstrapThemeCss(string theme = "default", string themePath = "~/Content/bootstrap-themes/")
        {
            if (themePath.IsNullOrWhiteSpace())
            {
                themePath = "~/Content/bootstrap-themes/";
            }
            else if (!themePath.Trim().EndsWith("/"))
            {
                themePath = themePath.Trim() + "/";
            }

            if (theme.IsNullOrWhiteSpace())
            {
                theme = "default";
            }

            string cssFileMin = themePath + theme + ".min.css";
            string cssFile = themePath + theme + ".css";

            if (T4MVCHelpers.IsProduction() && T4Extensions.FileExists(cssFileMin))
            {
                return T4MVCHelpers.ProcessVirtualPath(cssFileMin);
            }
            else if (T4Extensions.FileExists(cssFile))
            {
                return T4MVCHelpers.ProcessVirtualPath(cssFile);
            }
            else
            {
                return Links.Content.bootstrap_themes.default_css;
            }
        }

        public static string GetBootswatchThemeCss(string theme = "cerulean", string themePath = "~/Content/bootswatch/")
        {
            if (themePath.IsNullOrWhiteSpace())
            {
                themePath = "~/Content/bootswatch/";
            }
            else if (!themePath.Trim().EndsWith("/"))
            {
                themePath = themePath.Trim() + "/";
            }

            if (theme.IsNullOrWhiteSpace())
            {
                theme = "cerulean";
            }

            string cssFileMin = themePath + theme + "/bootstrap.min.css";
            string cssFile = themePath + theme + "/bootstrap.css";

            if (T4MVCHelpers.IsProduction() && T4Extensions.FileExists(cssFileMin))
            {
                return T4MVCHelpers.ProcessVirtualPath(cssFileMin);
            }
            else if (T4Extensions.FileExists(cssFile))
            {
                return T4MVCHelpers.ProcessVirtualPath(cssFile);
            }
            else
            {
                return Links.Content.bootstrap_themes.default_css;
            }
        }
    }
}
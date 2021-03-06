using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Routing;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Core
{
	internal class RouteInfo
	{
		public System.Web.Routing.RouteData RouteData { get; private set; }

		public RouteInfo(System.Web.Routing.RouteData data)
		{
            Contract.Requires<ArgumentNullException>(data != null, "data");

            RouteData = data;
		}

		public RouteInfo(Uri uri, string applicationPath)
		{
            Contract.Requires<ArgumentNullException>(uri != null, "uri");
            Contract.Requires<ArgumentNullException>(applicationPath != null, "applicationPath");
            Contract.Requires<ArgumentException>(!applicationPath.IsNullOrWhiteSpace());

            RouteData = RouteTable.Routes.GetRouteData(new RouteInfo.InternalHttpContext(uri, applicationPath));
		}

		private class InternalHttpContext : HttpContextBase
		{
			private readonly HttpRequestBase request;

			public InternalHttpContext(Uri uri, string applicationPath)
			{
                Contract.Requires<ArgumentNullException>(uri != null, "uri");
                Contract.Requires<ArgumentNullException>(applicationPath != null, "applicationPath");

                request = new RouteInfo.InternalRequestContext(uri, applicationPath);
			}

			public override HttpRequestBase Request
			{
				get
				{
					return request;
				}
			}
		}

		private class InternalRequestContext : HttpRequestBase
		{
			private readonly string appRelativePath;
			private readonly string pathInfo;

			public InternalRequestContext(Uri uri, string applicationPath)
			{
                Contract.Requires<ArgumentNullException>(uri != null, "uri");
                Contract.Requires<ArgumentNullException>(applicationPath != null, "applicationPath");

                pathInfo = uri.Query;

                if (!applicationPath.IsNullOrWhiteSpace() && uri.AbsolutePath.StartsWith(applicationPath, StringComparison.OrdinalIgnoreCase))
                {
                    appRelativePath = uri.AbsolutePath;
                }
                else
                {
                    appRelativePath = uri.AbsolutePath.Substring(applicationPath.Length);
                }
			}

			public override string AppRelativeCurrentExecutionFilePath
			{
				get
				{
					return string.Concat("~", appRelativePath);
				}
			}

			public override string PathInfo
			{
				get
				{
					return pathInfo;
				}
			}
		}
	}
}
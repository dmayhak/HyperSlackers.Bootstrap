using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;
using HyperSlackers.Bootstrap;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using System.Diagnostics;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
	public class NavBuilder<TModel> : DisposableHtmlElement<TModel, Nav>
	{
		internal readonly UrlHelper urlHelper;
		internal bool wrapTagControllerAware;
		internal bool wrapTagControllerAndActionAware;
		internal bool isSubNav;
        private bool disposed = false;

		internal NavBuilder(HtmlHelper<TModel> html, Nav nav) 
            : base(html, nav)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(nav != null, "nav");

			this.urlHelper = new UrlHelper(html.ViewContext.RequestContext);

			if (nav.activeLinksByController)
			{
				this.wrapTagControllerAware = true;
			}

			if (nav.activeLinksByControllerAndAction)
			{
				this.wrapTagControllerAndActionAware = true;
			}

            this.textWriter.Write(this.element.StartTag); // TODO: is this correct?
		}

		internal NavBuilder(HtmlHelper<TModel> html, SubNav subNav) 
            : base(html, subNav)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(subNav != null, "subNav");

            this.isSubNav = true;
            this.urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            this.wrapTagControllerAware = subNav.activeLinksByController;
            this.wrapTagControllerAndActionAware = subNav.activeLinksByControllerAndAction;
            string actionName = html.ViewContext.RouteData.GetRequiredString("action");
            string controllerName = html.ViewContext.RouteData.GetRequiredString("controller");
            string areaName = (html.ViewContext.RouteData.DataTokens.ContainsKey("area") ? html.ViewContext.RouteData.DataTokens["area"].ToString() : string.Empty);

            string liClass = "";
            try
            {
                Uri uri = new Uri(this.urlHelper.Action("", "", null, "http") + subNav.url);
                RouteData routeData = (new RouteInfo(uri, HttpContext.Current.Request.ApplicationPath)).RouteData;
                string areaRequiredString = (html.ViewContext.RouteData.DataTokens.ContainsKey("area") ? routeData.GetRequiredString("area") : string.Empty);
                string controllerRequiredString = routeData.GetRequiredString("controller");
                string actionRequiredString = routeData.GetRequiredString("action");

                Contract.Assume(areaRequiredString != null);

                if (this.wrapTagControllerAware && areaName.ToLowerInvariant() == areaRequiredString.ToLowerInvariant() && controllerName.ToLowerInvariant() == controllerRequiredString.ToLowerInvariant())
                {
                    liClass = " class=\"active\"";
                }
                if (this.wrapTagControllerAndActionAware && areaName.ToLower() == areaRequiredString.ToLower() && controllerName.ToLower() == controllerRequiredString.ToLower() && actionName.ToLower() == actionRequiredString.ToLower())
                {
                    liClass = " class=\"active\"";
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.Assert(false);
            }

            this.textWriter.Write(this.element.StartTag); // TODO: is this correct? or no?

            this.textWriter.Write(string.Format("<li{0}>", liClass));
            this.textWriter.Write(new LinkControl<TModel>(html, subNav.text, subNav.url));
            this.textWriter.Write("<ul class='nav'>");
		}

        public ActionLinkControl<TModel> ActionLink(string linkText, ActionResult result)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(result != null, "result");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return (new ActionLinkControl<TModel>(this.html, linkText, result)).WrapInto("li").WrapTagControllerAware(this.wrapTagControllerAware).WrapTagControllerAndActionAware(this.wrapTagControllerAndActionAware);
		}

        public ActionLinkControl<TModel> ActionLink(string linkText, Task<ActionResult> taskResult)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(taskResult != null, "taskResult");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return (new ActionLinkControl<TModel>(this.html, linkText, taskResult)).WrapInto("li").WrapTagControllerAware(this.wrapTagControllerAware).WrapTagControllerAndActionAware(this.wrapTagControllerAndActionAware);
		}

        public ActionLinkControl<TModel> ActionLink(string linkText, string actionName)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return (new ActionLinkControl<TModel>(this.html, linkText, actionName)).WrapInto("li").WrapTagControllerAware(this.wrapTagControllerAware).WrapTagControllerAndActionAware(this.wrapTagControllerAndActionAware);
		}

        public ActionLinkControl<TModel> ActionLink(string linkText, string actionName, string controllerName)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return (new ActionLinkControl<TModel>(this.html, linkText, actionName, controllerName)).WrapInto("li").WrapTagControllerAware(this.wrapTagControllerAware).WrapTagControllerAndActionAware(this.wrapTagControllerAndActionAware);
		}

        public ActionLinkControl<TModel> AjaxActionLink(string linkText, ActionResult result, AjaxOptions ajaxOptions)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(result != null, "result");
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            AjaxHelper<TModel> ajax = new AjaxHelper<TModel>(this.html.ViewContext, this.html.ViewDataContainer, this.html.RouteCollection);

            return (new ActionLinkControl<TModel>(ajax, linkText, result, ajaxOptions)).WrapInto("li").WrapTagControllerAware(this.wrapTagControllerAware).WrapTagControllerAndActionAware(this.wrapTagControllerAndActionAware);
		}

        public ActionLinkControl<TModel> AjaxActionLink(string linkText, string actionName, AjaxOptions ajaxOptions)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            AjaxHelper<TModel> ajax = new AjaxHelper<TModel>(this.html.ViewContext, this.html.ViewDataContainer, this.html.RouteCollection);

            return (new ActionLinkControl<TModel>(ajax, linkText, actionName, ajaxOptions)).WrapInto("li").WrapTagControllerAware(this.wrapTagControllerAware).WrapTagControllerAndActionAware(this.wrapTagControllerAndActionAware);
		}

        public ActionLinkControl<TModel> AjaxActionLink(string linkText, string actionName, string controllerName, AjaxOptions ajaxOptions)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            AjaxHelper<TModel> ajax = new AjaxHelper<TModel>(this.html.ViewContext, this.html.ViewDataContainer, this.html.RouteCollection);
            
            return (new ActionLinkControl<TModel>(ajax, linkText, actionName, controllerName, ajaxOptions)).WrapInto("li").WrapTagControllerAware(this.wrapTagControllerAware).WrapTagControllerAndActionAware(this.wrapTagControllerAndActionAware);
		}

        public DropDownBuilder<TModel> BeginDropDown(DropDown dropDown)
		{
            Contract.Requires<ArgumentNullException>(dropDown != null, "dropDown");
            Contract.Ensures(Contract.Result<DropDownBuilder<TModel>>() != null);

            return new DropDownBuilder<TModel>(this.html, dropDown, "li", new { @class = "dropdown" }, true);
		}

		public NavBuilder<TModel> BeginSubNav(SubNav subNav)
		{
            Contract.Requires<ArgumentNullException>(subNav != null, "subNav");
            Contract.Ensures(Contract.Result<NavBuilder<TModel>>() != null);

            return new NavBuilder<TModel>(this.html, subNav);
		}

		public IHtmlString Divider()
		{
            Contract.Ensures(Contract.Result<IHtmlString>() != null);

			return MvcHtmlString.Create("<li class=\"divider\"></li>");
		}

		public IHtmlString Header(string header)
		{
            Contract.Ensures(Contract.Result<IHtmlString>() != null);

			return MvcHtmlString.Create(string.Format("<li class=\"nav-header\">{0}</li>", header));
		}

        public LinkControl<TModel> Link(string linkText, string url)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!url.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

            return (new LinkControl<TModel>(this.html, linkText, url)).WrapInto("li");
		}

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (!this.disposed)
            {
                if (disposing)
                {
                    if (this.isSubNav)
                    {
                        this.textWriter.Write("</li></ul>");
                    }

                    this.disposed = true;
                }
            }
        }
	}
}
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using HyperSlackers.Bootstrap;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class DropDownBuilder<TModel> : DisposableHtmlElement<TModel, DropDown>
	{
		private readonly string wrapperTag;
		private readonly bool wrapTagControllerAware;
		private readonly bool wrapTagControllerAndActionAware;
        private bool disposed = false;

        internal DropDownBuilder(HtmlHelper<TModel> html, DropDown dropDown, string wrapperTag = null, object wrapperTagHtmlAttributes = null, bool withCaret = true) 
            : base(html, dropDown)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(dropDown != null, "dropDown");

            this.wrapperTag = wrapperTag;
			
			if (dropDown.activeLinksByController)
			{
				this.wrapTagControllerAware = true;
			}

			if (dropDown.activeLinksByControllerAndAction)
			{
				this.wrapTagControllerAndActionAware = true;
			}

            if (!this.wrapperTag.IsNullOrWhiteSpace())
            {
                TagBuilder wrapperTagBuilder = new TagBuilder(this.wrapperTag);

                wrapperTagBuilder.MergeHtmlAttributes(wrapperTagHtmlAttributes.ToDictionary().FormatHtmlAttributes());

                this.textWriter.Write(wrapperTagBuilder.ToString(TagRenderMode.StartTag));
            }

			TagBuilder linkTagBuilder = new TagBuilder("a");
			linkTagBuilder.AddOrMergeAttribute("data-toggle", "dropdown");
			linkTagBuilder.AddOrMergeAttribute("href", "#");

			if (this.wrapperTag != "li")
			{
				linkTagBuilder.AddCssClass(Helpers.GetCssClass(this.element.buttonSize));
				linkTagBuilder.AddCssClass(Helpers.GetCssClass(html, this.element.buttonStyle));
				linkTagBuilder.AddCssClass("btn dropdown-toggle");
			}

			linkTagBuilder.InnerHtml = this.element.actionText + (withCaret ? " <span class=\"caret\"></span>" : string.Empty);

            this.textWriter.Write(linkTagBuilder.ToString(TagRenderMode.Normal));

			TagBuilder menuTagBuilder = new TagBuilder("ul");
			menuTagBuilder.AddCssClass("dropdown-menu");

            if (this.element.allignToDirection.HasValue)
            {
                menuTagBuilder.AddCssClass(Helpers.GetCssClass(this.element.allignToDirection.Value));
            }

            this.textWriter.Write(menuTagBuilder.ToString(TagRenderMode.StartTag));
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

            return (new ActionLinkControl<TModel>(this.ajax, linkText, result, ajaxOptions)).WrapInto("li").WrapTagControllerAware(this.wrapTagControllerAware).WrapTagControllerAndActionAware(this.wrapTagControllerAndActionAware);
		}

        public ActionLinkControl<TModel> AjaxActionLink(string linkText, string actionName, AjaxOptions ajaxOptions)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            AjaxHelper<TModel> ajax = new AjaxHelper<TModel>(this.html.ViewContext, this.html.ViewDataContainer, this.html.RouteCollection);

            return (new ActionLinkControl<TModel>(this.ajax, linkText, actionName, ajaxOptions)).WrapInto("li").WrapTagControllerAware(this.wrapTagControllerAware).WrapTagControllerAndActionAware(this.wrapTagControllerAndActionAware);
		}

        public ActionLinkControl<TModel> AjaxActionLink(string linkText, string actionName, string controllerName, AjaxOptions ajaxOptions)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            AjaxHelper<TModel> ajax = new AjaxHelper<TModel>(this.html.ViewContext, this.html.ViewDataContainer, this.html.RouteCollection);

            return (new ActionLinkControl<TModel>(this.ajax, linkText, actionName, controllerName, ajaxOptions)).WrapInto("li").WrapTagControllerAware(this.wrapTagControllerAware).WrapTagControllerAndActionAware(this.wrapTagControllerAndActionAware);
		}

		public IHtmlString Divider()
		{
            Contract.Ensures(Contract.Result<IHtmlString>() != null);

			return MvcHtmlString.Create("<li class=\"divider\"></li>");
		}

		public IHtmlString Header(string header)
		{
            Contract.Requires<ArgumentException>(!header.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<IHtmlString>() != null);

            return MvcHtmlString.Create("<li class=\"dropdown-header\">{0}</li>".FormatWith(header));
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
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.textWriter.Write("</ul>");
                    if (!this.wrapperTag.IsNullOrWhiteSpace())
                    {
                        this.textWriter.Write(string.Format("</{0}>", this.wrapperTag));
                    }

                    this.disposed = true;
                }
            }

            base.Dispose(disposing);
        }
	}
}
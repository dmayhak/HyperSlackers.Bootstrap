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
                wrapTagControllerAware = true;
			}

			if (dropDown.activeLinksByControllerAndAction)
			{
                wrapTagControllerAndActionAware = true;
			}

            if (!this.wrapperTag.IsNullOrWhiteSpace())
            {
                TagBuilder wrapperTagBuilder = new TagBuilder(this.wrapperTag);

                wrapperTagBuilder.MergeHtmlAttributes(wrapperTagHtmlAttributes.ToDictionary().FormatHtmlAttributes());

                textWriter.Write(wrapperTagBuilder.ToString(TagRenderMode.StartTag));
            }

			TagBuilder linkTagBuilder = new TagBuilder("a");
			linkTagBuilder.AddOrMergeAttribute("data-toggle", "dropdown");
			linkTagBuilder.AddOrMergeAttribute("href", "#");

			if (this.wrapperTag != "li")
			{
				linkTagBuilder.AddCssClass(Helpers.GetCssClass(element.buttonSize));
				linkTagBuilder.AddCssClass(Helpers.GetCssClass(html, element.buttonStyle));
				linkTagBuilder.AddCssClass("btn dropdown-toggle");
			}

			linkTagBuilder.InnerHtml = element.actionText + (withCaret ? " <span class=\"caret\"></span>" : string.Empty);

            textWriter.Write(linkTagBuilder.ToString(TagRenderMode.Normal));

			TagBuilder menuTagBuilder = new TagBuilder("ul");
			menuTagBuilder.AddCssClass("dropdown-menu");

            if (element.allignToDirection.HasValue)
            {
                menuTagBuilder.AddCssClass(Helpers.GetCssClass(element.allignToDirection.Value));
            }

            textWriter.Write(menuTagBuilder.ToString(TagRenderMode.StartTag));
		}

        public ActionLinkControl<TModel> ActionLink(string linkText, ActionResult result, bool disabled = false)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(result != null, "result");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return (new ActionLinkControl<TModel>(html, linkText, result)).WrapInto(new WrapperTag("li").Disabled(disabled)).WrapTagControllerAware(wrapTagControllerAware).WrapTagControllerAndActionAware(wrapTagControllerAndActionAware);
		}

        public ActionLinkControl<TModel> ActionLink(string linkText, Task<ActionResult> taskResult, bool disabled = false)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(taskResult != null, "taskResult");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return (new ActionLinkControl<TModel>(html, linkText, taskResult)).WrapInto(new WrapperTag("li").Disabled(disabled)).WrapTagControllerAware(wrapTagControllerAware).WrapTagControllerAndActionAware(wrapTagControllerAndActionAware);
		}

        public ActionLinkControl<TModel> ActionLink(string linkText, string actionName, bool disabled = false)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return (new ActionLinkControl<TModel>(html, linkText, actionName)).WrapInto(new WrapperTag("li").Disabled(disabled)).WrapTagControllerAware(wrapTagControllerAware).WrapTagControllerAndActionAware(wrapTagControllerAndActionAware);
		}

        public ActionLinkControl<TModel> ActionLink(string linkText, string actionName, string controllerName, bool disabled = false)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return (new ActionLinkControl<TModel>(html, linkText, actionName, controllerName)).WrapInto(new WrapperTag("li").Disabled(disabled)).WrapTagControllerAware(wrapTagControllerAware).WrapTagControllerAndActionAware(wrapTagControllerAndActionAware);
		}

        public ActionLinkControl<TModel> AjaxActionLink(string linkText, ActionResult result, AjaxOptions ajaxOptions, bool disabled = false)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(result != null, "result");
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            AjaxHelper<TModel> ajax = new AjaxHelper<TModel>(html.ViewContext, html.ViewDataContainer, html.RouteCollection);

            return (new ActionLinkControl<TModel>(this.ajax, linkText, result, ajaxOptions)).WrapInto(new WrapperTag("li").Disabled(disabled)).WrapTagControllerAware(wrapTagControllerAware).WrapTagControllerAndActionAware(wrapTagControllerAndActionAware);
		}

        public ActionLinkControl<TModel> AjaxActionLink(string linkText, string actionName, AjaxOptions ajaxOptions, bool disabled = false)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            AjaxHelper<TModel> ajax = new AjaxHelper<TModel>(html.ViewContext, html.ViewDataContainer, html.RouteCollection);

            return (new ActionLinkControl<TModel>(this.ajax, linkText, actionName, ajaxOptions)).WrapInto(new WrapperTag("li").Disabled(disabled)).WrapTagControllerAware(wrapTagControllerAware).WrapTagControllerAndActionAware(wrapTagControllerAndActionAware);
		}

        public ActionLinkControl<TModel> AjaxActionLink(string linkText, string actionName, string controllerName, AjaxOptions ajaxOptions, bool disabled = false)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            AjaxHelper<TModel> ajax = new AjaxHelper<TModel>(html.ViewContext, html.ViewDataContainer, html.RouteCollection);

            return (new ActionLinkControl<TModel>(this.ajax, linkText, actionName, controllerName, ajaxOptions)).WrapInto(new WrapperTag("li").Disabled(disabled)).WrapTagControllerAware(wrapTagControllerAware).WrapTagControllerAndActionAware(wrapTagControllerAndActionAware);
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

        public LinkControl<TModel> Link(string linkText, string url, bool disabled = false)
		{
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!url.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

            return (new LinkControl<TModel>(html, linkText, url)).WrapInto(new WrapperTag("li").Disabled(disabled));
		}

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    textWriter.Write("</ul>");
                    if (!wrapperTag.IsNullOrWhiteSpace())
                    {
                        textWriter.Write(string.Format("</{0}>", wrapperTag));
                    }

                    disposed = true;
                }
            }

            base.Dispose(disposing);
        }
	}
}
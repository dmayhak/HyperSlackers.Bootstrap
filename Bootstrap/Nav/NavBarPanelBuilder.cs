using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;
using System.Web;

namespace HyperSlackers.Bootstrap.Controls
{
    public class NavBarPanelBuilder<TModel> : DisposableHtmlElement<TModel, NavBarPanel>
    {
        private bool disposed;

        internal NavBarPanelBuilder(HtmlHelper<TModel> html, NavBarPanel panel)
            : base(html, panel)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(panel != null, "panel");

            StringBuilder startTag = new StringBuilder();
            startTag.Append("<ul class=\"nav navbar-nav{0}\">".FormatWith(panel.alignRight ? " navbar-right" : ""));
            startTag.Append("");
            startTag.Append("");

            textWriter.Write(startTag.ToString());
        }

        public ActionLinkControl<TModel> ActionLink(string linkText, ActionResult result, bool active = false)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(result != null, "result");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return new ActionLinkControl<TModel>(html, linkText, result).WrapInto(new WrapperTag("li").Active(active));
        }

        public ActionLinkControl<TModel> ActionLink(string linkText, Task<ActionResult> taskResult, bool active = false)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(taskResult != null, "taskResult");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return new ActionLinkControl<TModel>(html, linkText, taskResult).WrapInto(new WrapperTag("li").Active(active));
        }

        public ActionLinkControl<TModel> ActionLink(string linkText, string actionName, bool active = false)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return new ActionLinkControl<TModel>(html, linkText, actionName).WrapInto(new WrapperTag("li").Active(active));
        }

        public ActionLinkControl<TModel> ActionLink(string linkText, string actionName, string controllerName, bool active = false)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return new ActionLinkControl<TModel>(html, linkText, actionName, controllerName).WrapInto(new WrapperTag("li").Active(active));
        }

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, ActionResult result, bool active = false)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(result != null, "result");
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            return new ActionLinkButtonControl<TModel>(html, linkText, result).ControlClass("navbar-btn").WrapInto(new WrapperTag("li").Active(active));
        }

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, Task<ActionResult> taskResult)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(taskResult != null, "taskResult");
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            return new ActionLinkButtonControl<TModel>(html, linkText, taskResult).ControlClass("navbar-btn").WrapInto(new WrapperTag("li"));
        }

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, string actionName)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            return new ActionLinkButtonControl<TModel>(html, linkText, actionName).ControlClass("navbar-btn").WrapInto(new WrapperTag("li"));
        }

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, string actionName, string controllerName)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            return new ActionLinkButtonControl<TModel>(html, linkText, actionName, controllerName).ControlClass("navbar-btn").WrapInto(new WrapperTag("li"));
        }

        public ButtonControl<TModel> Button()
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            return new ButtonControl<TModel>(html, ButtonType.Button).ControlClass("navbar-btn").WrapInto(new WrapperTag("li"));
        }

        public ButtonControl<TModel> Button(string text)
        {
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            return new ButtonControl<TModel>(html, ButtonType.Button).Text(text).ControlClass("navbar-btn").WrapInto(new WrapperTag("li"));
        }

        public LinkControl<TModel> Link(string linkText, string url)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!url.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

            return new LinkControl<TModel>(html, linkText, url).WrapInto(new WrapperTag("li"));
        }

        public DropDownBuilder<TModel> BeginDropDown(DropDown dropDown)
        {
            Contract.Requires<ArgumentNullException>(dropDown != null, "dropDown");
            Contract.Ensures(Contract.Result<DropDownBuilder<TModel>>() != null);

            return new DropDownBuilder<TModel>(html, dropDown, "li", new { @class = "dropdown" }, true); // TODO: add wrapper to builder classes?
        }

        public IHtmlString Text(string text)
        {
            Contract.Requires<ArgumentNullException>(!text.IsNullOrWhiteSpace(), "text");
            Contract.Ensures(Contract.Result<IHtmlString>() != null);

            return new HtmlString("<p class=\"navbar-text\">{0}</p>".FormatWith(text));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (!disposed)
            {
                if (disposing)
                {
                    textWriter.Write("</ul>");

                    disposed = true;
                }
            }
        }
    }
}

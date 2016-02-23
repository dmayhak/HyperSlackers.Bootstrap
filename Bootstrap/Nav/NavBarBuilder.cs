using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class NavBarBuilder<TModel> : DisposableHtmlElement<TModel, NavBar>
    {
        private bool disposed;

        internal NavBarBuilder(HtmlHelper<TModel> html, NavBar navBar)
            : base(html, navBar)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(navBar != null, "navBar");

            StringBuilder startTag = new StringBuilder();
            startTag.Append("<nav class=\"navbar ");
            if (element.inverse)
            {
                startTag.Append("navbar-inverse ");
            }
            else
            {
                startTag.Append("navbar-default ");
            }
            startTag.Append(Helpers.GetCssClass(element.alignment));
            startTag.Append("\">");

            startTag.Append("<div class=\"container{0}\">".FormatWith(element.fluidContainer ? "-fluid" : string.Empty));

            startTag.Append("<div class=\"navbar-header\">");
            startTag.Append("<button type=\"button\" class=\"navbar-toggle\" data-toggle=\"collapse\" data-target=\"#{0}\">".FormatWith(element.id));
            startTag.Append("<span class=\"sr-only\">Toggle navigation</span>");
            startTag.Append("<span class=\"icon-bar\"></span>");
            startTag.Append("<span class=\"icon-bar\"></span>");
            startTag.Append("<span class=\"icon-bar\"></span>");
            startTag.Append("</button>");
            startTag.Append("<a class=\"navbar-brand\" href=\"#\">{0}</a>".FormatWith(element.brand));
            startTag.Append("</div>");

            startTag.Append("<div class=\"collapse navbar-collapse\" id=\"{0}\">".FormatWith(element.id));

            textWriter.Write(startTag.ToString());
        }

        public NavBarPanelBuilder<TModel> BeginPanel(NavBarPanel panel)
        {
            Contract.Requires<ArgumentNullException>(panel != null, "panel");
            Contract.Ensures(Contract.Result<NavBarPanelBuilder<TModel>>() != null);

            return new NavBarPanelBuilder<TModel>(html, panel);
        }

        public NavBarFormBuilder<TModel> BeginForm(NavBarForm form)
        {
            Contract.Requires<ArgumentNullException>(form != null, "form");
            Contract.Ensures(Contract.Result<NavBarFormBuilder<TModel>>() != null);

            return new NavBarFormBuilder<TModel>(html, form);
        }

        //public ActionLinkControl<TModel> ActionLink(string linkText, ActionResult result, bool active = false)
        //{
        //    Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
        //    Contract.Requires<ArgumentNullException>(result != null, "result");
        //    Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

        //    return new ActionLinkControl<TModel>(html, linkText, result).WrapInto(new WrapperTag("li").Active(active));
        //}

        //public ActionLinkControl<TModel> ActionLink(string linkText, Task<ActionResult> taskResult, bool active = false)
        //{
        //    Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
        //    Contract.Requires<ArgumentNullException>(taskResult != null, "taskResult");
        //    Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

        //    return new ActionLinkControl<TModel>(html, linkText, taskResult).WrapInto(new WrapperTag("li").Active(active));
        //}

        //public ActionLinkControl<TModel> ActionLink(string linkText, string actionName, bool active = false)
        //{
        //    Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
        //    Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
        //    Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

        //    return new ActionLinkControl<TModel>(html, linkText, actionName).WrapInto(new WrapperTag("li").Active(active));
        //}

        //public ActionLinkControl<TModel> ActionLink(string linkText, string actionName, string controllerName, bool active = false)
        //{
        //    Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
        //    Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
        //    Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());
        //    Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

        //    return new ActionLinkControl<TModel>(html, linkText, actionName, controllerName).WrapInto(new WrapperTag("li").Active(active));
        //}

        //public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, ActionResult result, bool active = false)
        //{
        //    Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
        //    Contract.Requires<ArgumentNullException>(result != null, "result");
        //    Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

        //    return new ActionLinkButtonControl<TModel>(html, linkText, result).ControlClass("navbar-btn").WrapInto(new WrapperTag("li").Active(active));
        //}

        //public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, Task<ActionResult> taskResult)
        //{
        //    Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
        //    Contract.Requires<ArgumentNullException>(taskResult != null, "taskResult");
        //    Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

        //    return new ActionLinkButtonControl<TModel>(html, linkText, taskResult).ControlClass("navbar-btn").WrapInto(new WrapperTag("li"));
        //}

        //public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, string actionName)
        //{
        //    Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
        //    Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
        //    Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

        //    return new ActionLinkButtonControl<TModel>(html, linkText, actionName).ControlClass("navbar-btn").WrapInto(new WrapperTag("li"));
        //}

        //public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, string actionName, string controllerName)
        //{
        //    Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
        //    Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
        //    Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());
        //    Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

        //    return new ActionLinkButtonControl<TModel>(html, linkText, actionName, controllerName).ControlClass("navbar-btn").WrapInto(new WrapperTag("li"));
        //}

        //public ButtonControl<TModel> Button()
        //{
        //    Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

        //    return new ButtonControl<TModel>(html, ButtonType.Button).ControlClass("navbar-btn").WrapInto(new WrapperTag("li"));
        //}

        //public ButtonControl<TModel> Button(string text)
        //{
        //    Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
        //    Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

        //    return new ButtonControl<TModel>(html, ButtonType.Button).Text(text).ControlClass("navbar-btn").WrapInto(new WrapperTag("li"));
        //}

        //public LinkControl<TModel> Link(string linkText, string url)
        //{
        //    Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
        //    Contract.Requires<ArgumentException>(!url.IsNullOrWhiteSpace());
        //    Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

        //    return new LinkControl<TModel>(html, linkText, url).WrapInto(new WrapperTag("li"));
        //}

        //public DropDownBuilder<TModel> BeginDropDown(DropDown dropDown)
        //{
        //    Contract.Requires<ArgumentNullException>(dropDown != null, "dropDown");
        //    Contract.Ensures(Contract.Result<DropDownBuilder<TModel>>() != null);

        //    return new DropDownBuilder<TModel>(html, dropDown, "li", new { @class = "dropdown" }, true); // TODO: add wrapper to builder classes?
        //}

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (!disposed)
            {
                if (disposing)
                {
                    textWriter.Write("</div></div></div>");

                    disposed = true;
                }
            }
        }
    }
}

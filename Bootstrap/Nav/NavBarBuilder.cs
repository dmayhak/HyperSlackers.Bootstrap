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
        private bool liTagIsOpen;
        private bool disposed;

        internal NavBarBuilder(HtmlHelper<TModel> html, NavBar navBar) 
            : base(html, navBar)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(navBar != null, "navBar");

            StringBuilder startTag = new StringBuilder();
            startTag.Append("<nav class=\"navbar ");
            if (this.element.inverse)
            {
                startTag.Append("navbar-inverse ");
            }
            else
            {
                startTag.Append("navbar-default ");
            }
            startTag.Append(Helpers.GetCssClass(this.element.alignment));
            startTag.Append("\">");

            startTag.Append("<div class=\"container{0}\">".FormatWith(this.element.fluidContainer ? "-fluid" : string.Empty));

            startTag.Append("<div class=\"navbar-header\">");
            startTag.Append("<button type=\"button\" class=\"navbar-toggle\" data-toggle=\"collapse\" data-target=\"{0}\">".FormatWith(this.element.id));
            startTag.Append("<span class=\"sr-only\">Toggle navigation</span>");
            startTag.Append("<span class=\"icon-bar\"></span>");
            startTag.Append("<span class=\"icon-bar\"></span>");
            startTag.Append("<span class=\"icon-bar\"></span>");
            startTag.Append("</button>");
            startTag.Append("<a class=\"navbar-brand\" href=\"#\">{0}</a>".FormatWith(this.element.brand));
            startTag.Append("</div>");

            startTag.Append("<div class=\"collapse navbar-collapse\" id=\"{0}\">".FormatWith(this.element.id));
            startTag.Append("");
            startTag.Append("");
            startTag.Append("");

            this.textWriter.Write(startTag.ToString());
		}

        public ActionLinkControl<TModel> ActionLink(string linkText, ActionResult result)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(result != null, "result");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            OpenLiTag();

            return new ActionLinkControl<TModel>(this.html, linkText, result);
        }

        public ActionLinkControl<TModel> ActionLink(string linkText, Task<ActionResult> taskResult)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(taskResult != null, "taskResult");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            OpenLiTag();

            return new ActionLinkControl<TModel>(this.html, linkText, taskResult);
        }

        public ActionLinkControl<TModel> ActionLink(string linkText, string actionName)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            OpenLiTag();

            return new ActionLinkControl<TModel>(this.html, linkText, actionName);
        }

        public ActionLinkControl<TModel> ActionLink(string linkText, string actionName, string controllerName)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            OpenLiTag();

            return new ActionLinkControl<TModel>(this.html, linkText, actionName, controllerName);
        }

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, ActionResult result)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(result != null, "result");
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            OpenLiTag();

            return new ActionLinkButtonControl<TModel>(this.html, linkText, result).ControlClass("navbar-btn");
        }

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, Task<ActionResult> taskResult)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(taskResult != null, "taskResult");
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            OpenLiTag();

            return new ActionLinkButtonControl<TModel>(this.html, linkText, taskResult).ControlClass("navbar-btn");
        }

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, string actionName)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            OpenLiTag();

            return new ActionLinkButtonControl<TModel>(this.html, linkText, actionName).ControlClass("navbar-btn");
        }

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, string actionName, string controllerName)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            OpenLiTag();

            return new ActionLinkButtonControl<TModel>(this.html, linkText, actionName, controllerName).ControlClass("navbar-btn");
        }

        public ButtonControl<TModel> Button()
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            OpenLiTag();

            return new ButtonControl<TModel>(this.html, ButtonType.Button).ControlClass("navbar-btn");
        }

        public ButtonControl<TModel> Button(string text)
        {
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            OpenLiTag();

            return new ButtonControl<TModel>(this.html, ButtonType.Button).Text(text).ControlClass("navbar-btn");
        }

        public LinkControl<TModel> Link(string linkText, string url)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!url.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

            OpenLiTag();

            return new LinkControl<TModel>(this.html, linkText, url);
        }

        public DropDownBuilder<TModel> BeginDropDown(DropDown dropDown)
        {
            Contract.Requires<ArgumentNullException>(dropDown != null, "dropDown");
            Contract.Ensures(Contract.Result<DropDownBuilder<TModel>>() != null);

            OpenLiTag();

            return new DropDownBuilder<TModel>(this.html, dropDown, "div", new { @class = "dropdown" }, true);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (!this.disposed)
            {
                if (disposing)
                {
                    if (this.liTagIsOpen)
                    {
                        this.textWriter.Write("</li>");
                    }

                    this.textWriter.Write("</div></div></div>");

                    this.disposed = true;
                }
            }
        }
	
        private void OpenLiTag()
        {
            if (this.liTagIsOpen)
            {
                this.textWriter.Write("</li>");
            }
            else
            {
                this.liTagIsOpen = true;
            }

            this.textWriter.Write("<li>");
        }
    }
}

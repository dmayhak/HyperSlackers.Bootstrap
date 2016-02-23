using System;
using System.IO;
using System.Web.Mvc;
using HyperSlackers.Bootstrap;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using System.Threading.Tasks;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class AlertBuilder<TModel> : DisposableHtmlElement<TModel, Alert>
	{
		internal AlertBuilder(HtmlHelper<TModel> html, Alert alert)
            : base(html, alert)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(alert != null, "alert");

            textWriter.Write(element.StartTag);

			if (element.isDismissible)
			{
                textWriter.Write("<button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>");
			}
		}

        public ActionLinkControl<TModel> ActionLink(string linkText, ActionResult result)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(result != null, "result");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return new ActionLinkControl<TModel>(html, linkText, result).AlertLink();
        }

        public ActionLinkControl<TModel> ActionLink(string linkText, Task<ActionResult> taskResult)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(taskResult != null, "taskResult");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return new ActionLinkControl<TModel>(html, linkText, taskResult).AlertLink();
        }

        public ActionLinkControl<TModel> ActionLink(string linkText, string actionName)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return new ActionLinkControl<TModel>(html, linkText, actionName).AlertLink();
        }

        public ActionLinkControl<TModel> ActionLink(string linkText, string actionName, string controllerName)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return new ActionLinkControl<TModel>(html, linkText, actionName, controllerName).AlertLink();
        }

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, ActionResult result)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(result != null, "result");
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            return new ActionLinkButtonControl<TModel>(html, linkText, result).AlertLink();
        }

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, Task<ActionResult> taskResult)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(taskResult != null, "taskResult");
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            return new ActionLinkButtonControl<TModel>(html, linkText, taskResult).AlertLink();
        }

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, string actionName)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            return new ActionLinkButtonControl<TModel>(html, linkText, actionName).AlertLink();
        }

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, string actionName, string controllerName)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            return new ActionLinkButtonControl<TModel>(html, linkText, actionName, controllerName).AlertLink();
        }

        public LinkControl<TModel> Link(string linkText, string url)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!url.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

            return new LinkControl<TModel>(html, linkText, url).AlertLink();
        }
	}
}
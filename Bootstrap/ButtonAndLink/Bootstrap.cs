using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Bootstrap;
using HyperSlackers.Bootstrap.Controls;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.BootstrapMethods
{
    public partial class Bootstrap<TModel>
    {
        public ActionLinkControl<TModel> ActionLink(string linkText, ActionResult result)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(result != null, "result");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return new ActionLinkControl<TModel>(html, linkText, result);
        }

        public ActionLinkControl<TModel> ActionLink(string linkText, Task<ActionResult> taskResult)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(taskResult != null, "taskResult");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return new ActionLinkControl<TModel>(html, linkText, taskResult);
        }

        public ActionLinkControl<TModel> ActionLink(string linkText, string actionName)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return new ActionLinkControl<TModel>(html, linkText, actionName);
        }

        public ActionLinkControl<TModel> ActionLink(string linkText, string actionName, string controllerName)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return new ActionLinkControl<TModel>(html, linkText, actionName, controllerName);
        }

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, ActionResult result)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(result != null, "result");
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            return new ActionLinkButtonControl<TModel>(html, linkText, result);
        }

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, Task<ActionResult> taskResult)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(taskResult != null, "taskResult");
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            return new ActionLinkButtonControl<TModel>(html, linkText, taskResult);
        }

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, string actionName)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            return new ActionLinkButtonControl<TModel>(html, linkText, actionName);
        }

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, string actionName, string controllerName)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            return new ActionLinkButtonControl<TModel>(html, linkText, actionName, controllerName);
        }

        public ButtonToolbarBuilder<TModel> BeginButtonToolbar()
        {
            Contract.Ensures(Contract.Result<ButtonToolbarBuilder<TModel>>() != null);

            return BeginButtonToolbar(new ButtonToolbar());
        }

        public ButtonToolbarBuilder<TModel> BeginButtonToolbar(ButtonToolbar buttonToolbar)
        {
            Contract.Requires<ArgumentNullException>(buttonToolbar != null, "buttonToolbar");
            Contract.Ensures(Contract.Result<ButtonToolbarBuilder<TModel>>() != null);

            return new ButtonToolbarBuilder<TModel>(html, buttonToolbar);
        }

        public ButtonGroupBuilder<TModel> BeginButtonGroup()
        {
            Contract.Ensures(Contract.Result<ButtonGroupBuilder<TModel>>() != null);

            return BeginButtonGroup(new ButtonGroup());
        }

        public ButtonGroupBuilder<TModel> BeginButtonGroup(ButtonGroup buttonGroup)
        {
            Contract.Requires<ArgumentNullException>(buttonGroup != null, "buttonGroup");
            Contract.Ensures(Contract.Result<ButtonGroupBuilder<TModel>>() != null);

            return new ButtonGroupBuilder<TModel>(html, buttonGroup);
        }

        public ButtonControl<TModel> Button()
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            return new ButtonControl<TModel>(html, ButtonType.Button);
        }

        public ButtonControl<TModel> Button(string text)
        {
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            return new ButtonControl<TModel>(html, ButtonType.Button).Text(text);
        }

        public ButtonControl<TModel> SubmitButton()
        {
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            return new ButtonControl<TModel>(html, ButtonType.Submit);
        }

        public ButtonControl<TModel> SubmitButton(string text)
        {
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ButtonControl<TModel>>() != null);

            return new ButtonControl<TModel>(html, ButtonType.Submit).Text(text);
        }

        public LinkControl<TModel> Link(string linkText, string url)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!url.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<LinkControl<TModel>>() != null);

            return new LinkControl<TModel>(html, linkText, url);
        }

        public LinkButtonControl<TModel> LinkButton(string linkText, string url)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!url.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<LinkButtonControl<TModel>>() != null);

            return new LinkButtonControl<TModel>(html, linkText, url);
        }
    }
}
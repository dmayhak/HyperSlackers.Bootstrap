using System;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using HyperSlackers.Bootstrap;
using HyperSlackers.Bootstrap.BootstrapMethods;
using HyperSlackers.Bootstrap.Controls;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.BootstrapMethods
{

    public partial class BootstrapAjax<TModel>
    {
        public ActionLinkControl<TModel> ActionLink(string linkText, ActionResult result, AjaxOptions ajaxOptions)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(result != null, "result");
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return new ActionLinkControl<TModel>(ajax, linkText, result, ajaxOptions);
        }

        public ActionLinkControl<TModel> ActionLink(string linkText, string actionName, AjaxOptions ajaxOptions)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return new ActionLinkControl<TModel>(ajax, linkText, actionName, ajaxOptions);
        }

        public ActionLinkControl<TModel> ActionLink(string linkText, string actionName, string controllerName, AjaxOptions ajaxOptions)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            return new ActionLinkControl<TModel>(ajax, linkText, actionName, controllerName, ajaxOptions);
        }

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, ActionResult result, AjaxOptions ajaxOptions)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(result != null, "result");
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            return new ActionLinkButtonControl<TModel>(ajax, linkText, result, ajaxOptions);
        }

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, string actionName, AjaxOptions ajaxOptions)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            return new ActionLinkButtonControl<TModel>(ajax, linkText, actionName, ajaxOptions);
        }

        public ActionLinkButtonControl<TModel> ActionLinkButton(string linkText, string actionName, string controllerName, AjaxOptions ajaxOptions)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            return new ActionLinkButtonControl<TModel>(ajax, linkText, actionName, controllerName, ajaxOptions);
        }
    }
}
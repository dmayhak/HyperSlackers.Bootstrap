using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using HyperSlackers.Bootstrap;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class ActionLinkControl<TModel> : ControlBase<ActionLinkControl<TModel>, TModel>
	{
        internal readonly AjaxHelper<TModel> ajax; // TODO: ajaxable control base?
		internal readonly ActionResult result;
		internal readonly Task<ActionResult> taskResult;
		internal readonly AjaxOptions ajaxOptions;
		internal readonly ActionType actionTypePassed;
		internal string linkText;
		internal string routeName;
		internal readonly string actionName;
		internal readonly string controllerName;
		internal string protocol;
		internal string hostName;
		internal string fragment;
		// TODO: internal bool disabled;
		internal bool isDropDownToggle;
		internal RouteValueDictionary routeValues = new RouteValueDictionary();
		internal Icon iconPrepend;
		internal Icon iconAppend;
        internal bool wrapTagControllerAware;
		internal bool wrapTagControllerAndActionAware;
		internal string title;
		internal Tooltip tooltip;
        internal Badge badge;

        internal ActionLinkControl(HtmlHelper<TModel> html, string linkText, ActionResult result)
            : base(html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(result != null, "result");

			this.linkText = linkText;
			this.result = result;
            actionTypePassed = ActionType.HtmlActionResult;
		}

        internal ActionLinkControl(HtmlHelper<TModel> html, string linkText, Task<ActionResult> taskResult)
            : base(html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(taskResult != null, "taskResult");

			this.linkText = linkText;
			this.taskResult = taskResult;
            actionTypePassed = ActionType.HtmlTaskResult;
		}

        internal ActionLinkControl(HtmlHelper<TModel> html, string linkText, string actionName)
            : base(html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());

			this.linkText = linkText;
			this.actionName = actionName;
            actionTypePassed = ActionType.HtmlRegular;
		}

        internal ActionLinkControl(HtmlHelper<TModel> html, string linkText, string actionName, string controllerName)
            : base(html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());

			this.linkText = linkText;
			this.actionName = actionName;
			this.controllerName = controllerName;
            actionTypePassed = ActionType.HtmlRegular;
		}

        internal ActionLinkControl(AjaxHelper<TModel> ajax, string linkText, ActionResult result, AjaxOptions ajaxOptions)
            : base(new HtmlHelper<TModel>(ajax.ViewContext, ajax.ViewDataContainer, ajax.RouteCollection))
		{
            Contract.Requires<ArgumentNullException>(ajax != null, "ajax");
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(result != null, "result");
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");

			this.ajax = ajax;
			this.linkText = linkText;
			this.result = result;
			this.ajaxOptions = ajaxOptions;
            actionTypePassed = ActionType.AjaxActionResult;
		}

        internal ActionLinkControl(AjaxHelper<TModel> ajax, string linkText, Task<ActionResult> taskResult, AjaxOptions ajaxOptions)
            : base(new HtmlHelper<TModel>(ajax.ViewContext, ajax.ViewDataContainer, ajax.RouteCollection))
		{
            Contract.Requires<ArgumentNullException>(ajax != null, "ajax");
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(taskResult != null, "taskResult");
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");

			this.ajax = ajax;
			this.linkText = linkText;
			this.taskResult = taskResult;
			this.ajaxOptions = ajaxOptions;
            actionTypePassed = ActionType.AjaxTaskResult;
		}

        internal ActionLinkControl(AjaxHelper<TModel> ajax, string linkText, string actionName, AjaxOptions ajaxOptions)
            : base(new HtmlHelper<TModel>(ajax.ViewContext, ajax.ViewDataContainer, ajax.RouteCollection))
		{
            Contract.Requires<ArgumentNullException>(ajax != null, "ajax");
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrEmpty());
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");

			this.ajax = ajax;
			this.linkText = linkText;
			this.actionName = actionName;
			this.ajaxOptions = ajaxOptions;
            actionTypePassed = ActionType.AjaxRegular;
		}

        internal ActionLinkControl(AjaxHelper<TModel> ajax, string linkText, string actionName, string controllerName, AjaxOptions ajaxOptions)
            : base(new HtmlHelper<TModel>(ajax.ViewContext, ajax.ViewDataContainer, ajax.RouteCollection))
		{
            Contract.Requires<ArgumentNullException>(ajax != null, "ajax");
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");

			this.ajax = ajax;
			this.linkText = linkText;
			this.actionName = actionName;
			this.controllerName = controllerName;
			this.ajaxOptions = ajaxOptions;
            actionTypePassed = ActionType.AjaxRegular;
		}

        public ActionLinkControl<TModel> AppendIcon(GlyphIcon icon)
		{
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            iconAppend = icon;

			return this;
		}

        public ActionLinkControl<TModel> AppendIcon(GlyphIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            iconAppend = new GlyphIcon(icon, isWhite);

            return this;
        }

        public ActionLinkControl<TModel> AppendIcon(FontAwesomeIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            iconAppend = icon;

            return this;
        }

        public ActionLinkControl<TModel> AppendIcon(FontAwesomeIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            iconAppend = new FontAwesomeIcon(icon, isWhite);

            return this;
        }

        public ActionLinkControl<TModel> AppendIcon(string cssClass)
		{
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            iconAppend = new GlyphIcon(cssClass);

			return this;
		}

        //public ActionLinkControl<TModel> Disabled(bool isDisabled = true)
        //{
        //    Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

        //    this.disabled = isDisabled;

        //    return this;
        //}

        public ActionLinkControl<TModel> DropDownToggle()
		{
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            isDropDownToggle = true;

			return this;
		}

        public ActionLinkControl<TModel> Fragment(string fragment)
		{
            Contract.Requires<ArgumentException>(!fragment.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

			this.fragment = fragment;

			return this;
		}

        public ActionLinkControl<TModel> HostName(string hostName)
		{
            Contract.Requires<ArgumentException>(!hostName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

			this.hostName = hostName;

			return this;
		}

        public ActionLinkControl<TModel> PrependIcon(GlyphIcon icon)
		{
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            iconPrepend = icon;

			return this;
		}

        public ActionLinkControl<TModel> PrependIcon(GlyphIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            iconPrepend = new GlyphIcon(icon, isWhite);

            return this;
        }

        public ActionLinkControl<TModel> PrependIcon(FontAwesomeIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            iconPrepend = icon;

            return this;
        }

        public ActionLinkControl<TModel> PrependIcon(FontAwesomeIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            iconPrepend = new FontAwesomeIcon(icon, isWhite);

            return this;
        }

        public ActionLinkControl<TModel> PrependIcon(string cssClass)
		{
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            iconPrepend = new GlyphIcon(cssClass);

            return this;
		}

        public ActionLinkControl<TModel> Protocol(string protocol)
		{
            Contract.Requires<ArgumentException>(!protocol.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

			this.protocol = protocol;

			return this;
		}

        public ActionLinkControl<TModel> RouteName(string routeName)
		{
            Contract.Requires<ArgumentException>(!routeName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

			this.routeName = routeName;

			return this;
		}

        public ActionLinkControl<TModel> RouteValues(object routeValues)
		{
            Contract.Requires<ArgumentNullException>(routeValues != null, "routeValues");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

			this.routeValues.AddOrReplaceHtmlAttributes(routeValues.ToDictionary());

			return this;
		}

        public ActionLinkControl<TModel> RouteValues(RouteValueDictionary routeValues)
		{
            Contract.Requires<ArgumentNullException>(routeValues != null, "routeValues");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

			this.routeValues.AddOrReplaceHtmlAttributes(routeValues);

			return this;
		}

		public ActionLinkControl<TModel> Title(string title)
		{
            Contract.Requires<ArgumentException>(!title.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

			this.title = title;

			return this;
		}

        public ActionLinkControl<TModel> Tooltip(Tooltip tooltip)
		{
            Contract.Requires<ArgumentNullException>(tooltip != null, "tooltip");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

			this.tooltip = tooltip;

			return this;
		}

        public ActionLinkControl<TModel> Tooltip(string text)
		{
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            tooltip = new Tooltip(text);

			return this;
		}

        public ActionLinkControl<TModel> Tooltip(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            tooltip = new Tooltip(html);

            return this;
        }

        internal ActionLinkControl<TModel> WrapTagControllerAndActionAware(bool aware)
		{
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            wrapTagControllerAndActionAware = aware;

			return this;
		}

        internal ActionLinkControl<TModel> WrapTagControllerAware(bool aware)
		{
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            wrapTagControllerAware = aware;

			return this;
		}

        internal ActionLinkControl<TModel> AlertLink()
        {
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            ControlClass("alert-link");

            return this;
        }

        public ActionLinkControl<TModel> Badge(string text)
        {
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkControl<TModel>>() != null);

            badge = new Controls.Badge(text);
            return this;
        }

        protected override string Render()
		{
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

			IDictionary<string, object> attributes = controlHtmlAttributes.FormatHtmlAttributes();

            if (tooltip != null)
            {
                attributes.AddOrReplaceHtmlAttributes(tooltip.ToDictionary());
            }

            if (!id.IsNullOrWhiteSpace())
            {
                attributes.AddOrReplaceHtmlAttribute("id", id);
            }

            if (isDropDownToggle)
            {
                attributes.AddIfNotExistsCssClass("dropdown-toggle");
                attributes.Add("data-toggle", "dropdown");
            }

            //if (this.disabled)
            //{
            //    attributes.AddClass("disabled");
            //    attributes.Add("onclick", "return false");
            //}

            if (!title.IsNullOrWhiteSpace())
            {
                attributes.AddOrReplaceHtmlAttribute("title", title);
            }

            string replaceMe = Guid.NewGuid().ToString();
            string linkText = replaceMe;
            string prepend = string.Empty;
            string append = string.Empty;

            if (iconPrepend != null || iconAppend != null)
            {
                if (iconPrepend != null)
                {
                    prepend = iconPrepend.ToHtmlString() + " ";
                }
                if (iconAppend != null)
                {
                    append = " " + iconAppend.ToHtmlString();
                }
            }

            string linkHtml = string.Empty;
            string controllerName = "";
            string actionName = "";
            string areaName = "";
            switch (actionTypePassed)
            {
                case ActionType.HtmlRegular:
                    {
                        if (routeValues == null || !routeValues.ContainsKey("area"))
                        {
                            areaName = (html.ViewContext.RouteData.DataTokens.ContainsKey("area") ? html.ViewContext.RouteData.DataTokens["area"].ToString() : string.Empty);
                        }
                        else
                        {
                            areaName = routeValues["area"].ToString();
                        }
                        controllerName = (this.controllerName.IsNullOrWhiteSpace() ? html.ViewContext.RouteData.GetRequiredString("controller") : this.controllerName);
                        actionName = this.actionName;
                        linkHtml = html.ActionLink(replaceMe, this.actionName, this.controllerName, protocol, hostName, fragment, routeValues, attributes).ToHtmlString();
                        break;
                    }
                case ActionType.HtmlActionResult:
                    {
                        areaName = (result.GetRouteValueDictionary().ContainsKey("area") ? result.GetRouteValueDictionary()["area"].ToString() : string.Empty);
                        controllerName = result.GetRouteValueDictionary()["controller"].ToString();
                        actionName = result.GetRouteValueDictionary()["action"].ToString();
                        linkHtml = html.ActionLink(replaceMe, result, attributes, protocol, hostName, fragment).ToHtmlString();
                        break;
                    }
                case ActionType.HtmlTaskResult:
                    {
                        areaName = (taskResult.Result.GetRouteValueDictionary().ContainsKey("area") ? taskResult.Result.GetRouteValueDictionary()["area"].ToString() : string.Empty);
                        controllerName = taskResult.Result.GetRouteValueDictionary()["controller"].ToString();
                        actionName = taskResult.Result.GetRouteValueDictionary()["action"].ToString();
                        linkHtml = html.ActionLink(replaceMe, taskResult, attributes, protocol, hostName, fragment).ToHtmlString();
                        break;
                    }
                case ActionType.AjaxRegular:
                    {
                        if (routeValues == null || !routeValues.ContainsKey("area"))
                        {
                            areaName = (ajax.ViewContext.RouteData.DataTokens.ContainsKey("area") ? ajax.ViewContext.RouteData.DataTokens["area"].ToString() : string.Empty);
                        }
                        else
                        {
                            areaName = routeValues["area"].ToString();
                        }
                        controllerName = (this.controllerName.IsNullOrWhiteSpace() ? ajax.ViewContext.RouteData.GetRequiredString("controller") : this.controllerName);
                        actionName = this.actionName;
                        linkHtml = ajax.ActionLink(replaceMe, this.actionName, this.controllerName, protocol, hostName, fragment, routeValues, ajaxOptions, attributes).ToHtmlString();
                        break;
                    }
                case ActionType.AjaxActionResult:
                    {
                        areaName = (result.GetRouteValueDictionary().ContainsKey("area") ? result.GetRouteValueDictionary()["area"].ToString() : string.Empty);
                        controllerName = result.GetRouteValueDictionary()["controller"].ToString();
                        actionName = result.GetRouteValueDictionary()["action"].ToString();
                        linkHtml = ajax.ActionLink(replaceMe, result, ajaxOptions, attributes).ToHtmlString();
                        break;
                    }
                case ActionType.AjaxTaskResult:
                    {
                        areaName = (taskResult.Result.GetRouteValueDictionary().ContainsKey("area") ? taskResult.Result.GetRouteValueDictionary()["area"].ToString() : string.Empty);
                        controllerName = taskResult.Result.GetRouteValueDictionary()["controller"].ToString();
                        actionName = taskResult.Result.GetRouteValueDictionary()["action"].ToString();
                        linkHtml = ajax.ActionLink(replaceMe, taskResult, ajaxOptions, attributes).ToHtmlString();
                        break;
                    }
            }

            linkHtml = linkHtml.Replace(replaceMe, prepend + this.linkText + (badge == null ? "" : " {0}".FormatWith(badge.ToHtmlString())) + append);

            if (wrapper != null)
            {
                string actionRequiredString = string.Empty;
                string controllerRequiredString = string.Empty;
                string areaRequiredString = string.Empty;
                switch (actionTypePassed)
                {
                    case ActionType.HtmlRegular:
                    case ActionType.HtmlActionResult:
                    case ActionType.HtmlTaskResult:
                        {
                            actionRequiredString = html.ViewContext.RouteData.GetRequiredString("action");
                            controllerRequiredString = html.ViewContext.RouteData.GetRequiredString("controller");
                            areaRequiredString = (html.ViewContext.RouteData.DataTokens.ContainsKey("area") ? html.ViewContext.RouteData.DataTokens["area"].ToString() : string.Empty);
                            break;
                        }
                    case ActionType.AjaxRegular:
                    case ActionType.AjaxActionResult:
                    case ActionType.AjaxTaskResult:
                        {
                            actionRequiredString = ajax.ViewContext.RouteData.GetRequiredString("action");
                            controllerRequiredString = ajax.ViewContext.RouteData.GetRequiredString("controller");
                            areaRequiredString = (ajax.ViewContext.RouteData.DataTokens.ContainsKey("area") ? ajax.ViewContext.RouteData.DataTokens["area"].ToString() : string.Empty);
                            break;
                        }
                }

                Contract.Assume(controllerName != null);
                Contract.Assume(controllerRequiredString != null);
                Contract.Assume(actionRequiredString != null);
                Contract.Assume(actionName != null);
                Contract.Assert(areaRequiredString != null);

                if (wrapTagControllerAware && areaRequiredString.ToLower() == areaName.ToLower() && controllerRequiredString.ToLower() == controllerName.ToLower())
                {
                    wrapper.Active();
                }
                if (wrapTagControllerAndActionAware && areaRequiredString.ToLower() == areaName.ToLower() && controllerRequiredString.ToLower() == controllerName.ToLower() && actionRequiredString.ToLower() == actionName.ToLower())
                {
                    wrapper.Active();
                }

                linkHtml = WrapperTagFromatString().FormatWith(linkHtml);
            }

            return MvcHtmlString.Create(linkHtml).ToString();
		}
	}
}
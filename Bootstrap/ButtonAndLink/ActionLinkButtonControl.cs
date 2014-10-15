using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using HyperSlackers.Bootstrap;
using System.Diagnostics.Contracts;
using System.Text;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class ActionLinkButtonControl<TModel> : ControlBase<ActionLinkButtonControl<TModel>, TModel>
    {
        internal readonly AjaxHelper ajax;
        internal readonly ActionResult result;
        internal readonly Task<ActionResult> taskResult;
        internal readonly AjaxOptions ajaxOptions;
        internal readonly ActionType actionTypePassed;
        internal string routeName;
        internal string actionName;
        internal string controllerName;
        internal string protocol;
        internal string hostName;
        internal string fragment;
        internal string title;
        internal RouteValueDictionary routeValues = new RouteValueDictionary();
        internal bool isTextHtml;
        internal bool buttonBlock;
        internal bool disabled;
        internal Icon iconAppend;
        internal Icon iconPrepend;
        internal bool isDropDownToggle;
        internal string loadingText;
        internal string name;
        internal ButtonSize size = ButtonSize.Default;
        internal ButtonStyle style = ButtonStyle.Default;
        internal string text;
        internal Tooltip tooltip;
        internal string value;

        internal ActionLinkButtonControl(HtmlHelper<TModel> html, string linkText, ActionResult result) 
            : base(html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(result != null, "result");

            this.text = linkText;
            this.result = result;
            this.size = ButtonSize.Default;
            this.actionTypePassed = ActionType.HtmlActionResult;
        }

        internal ActionLinkButtonControl(HtmlHelper<TModel> html, string linkText, Task<ActionResult> taskResult)
            : base(html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(taskResult != null, "taskResult");

            this.text = linkText;
            this.taskResult = taskResult;
            this.size = ButtonSize.Default;
            this.actionTypePassed = ActionType.HtmlTaskResult;
        }

        internal ActionLinkButtonControl(HtmlHelper<TModel> html, string linkText, string actionName)
            : base(html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());

            this.text = linkText;
            this.actionName = actionName;
            this.size = ButtonSize.Default;
            this.actionTypePassed = ActionType.HtmlRegular;
        }

        internal ActionLinkButtonControl(HtmlHelper<TModel> html, string linkText, string actionName, string controllerName)
            : base(html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());

            this.text = linkText;
            this.actionName = actionName;
            this.controllerName = controllerName;
            this.size = ButtonSize.Default;
            this.actionTypePassed = ActionType.HtmlRegular;
        }

        internal ActionLinkButtonControl(AjaxHelper<TModel> ajax, string linkText, ActionResult result, AjaxOptions ajaxOptions) 
            : base(new HtmlHelper<TModel>(ajax.ViewContext, ajax.ViewDataContainer, ajax.RouteCollection))
        {
            Contract.Requires<ArgumentNullException>(ajax != null, "ajax");
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(result != null, "result");
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");

            this.ajax = ajax;
            this.text = linkText;
            this.result = result;
            this.size = ButtonSize.Default;
            this.ajaxOptions = ajaxOptions;
            this.actionTypePassed = ActionType.AjaxActionResult;
        }

        internal ActionLinkButtonControl(AjaxHelper<TModel> ajax, string linkText, Task<ActionResult> taskResult, AjaxOptions ajaxOptions)
            : base(new HtmlHelper<TModel>(ajax.ViewContext, ajax.ViewDataContainer, ajax.RouteCollection))
        {
            Contract.Requires<ArgumentNullException>(ajax != null, "ajax");
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(taskResult != null, "taskResult");
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");

            this.ajax = ajax;
            this.text = linkText;
            this.taskResult = taskResult;
            this.size = ButtonSize.Default;
            this.ajaxOptions = ajaxOptions;
            this.actionTypePassed = ActionType.AjaxTaskResult;
        }

        internal ActionLinkButtonControl(AjaxHelper<TModel> ajax, string linkText, string actionName, AjaxOptions ajaxOptions)
            : base(new HtmlHelper<TModel>(ajax.ViewContext, ajax.ViewDataContainer, ajax.RouteCollection))
        {
            Contract.Requires<ArgumentNullException>(ajax != null, "ajax");
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");

            this.ajax = ajax;
            this.text = linkText;
            this.actionName = actionName;
            this.size = ButtonSize.Default;
            this.ajaxOptions = ajaxOptions;
            this.actionTypePassed = ActionType.AjaxRegular;
        }

        internal ActionLinkButtonControl(AjaxHelper<TModel> ajax, string linkText, string actionName, string controllerName, AjaxOptions ajaxOptions)
            : base(new HtmlHelper<TModel>(ajax.ViewContext, ajax.ViewDataContainer, ajax.RouteCollection))
        {
            Contract.Requires<ArgumentNullException>(ajax != null, "ajax");
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!actionName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controllerName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");

            this.ajax = ajax;
            this.text = linkText;
            this.actionName = actionName;
            this.controllerName = controllerName;
            this.size = ButtonSize.Default;
            this.ajaxOptions = ajaxOptions;
            this.actionTypePassed = ActionType.AjaxRegular;
        }

        public ActionLinkButtonControl<TModel> Active()
        {
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.ControlClass("active");

            return this;
        }

        public ActionLinkButtonControl<TModel> AppendIcon(GlyphIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.iconAppend = icon;

            return this;
        }

        public ActionLinkButtonControl<TModel> AppendIcon(FontAwesomeIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.iconAppend = icon;

            return this;
        }

        public ActionLinkButtonControl<TModel> AppendIcon(GlyphIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.iconAppend = new GlyphIcon(icon, isWhite);

            return this;
        }

        public ActionLinkButtonControl<TModel> AppendIcon(FontAwesomeIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.iconAppend = new FontAwesomeIcon(icon, isWhite);

            return this;
        }

        public ActionLinkButtonControl<TModel> AppendIcon(string cssClass)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.iconAppend = new GlyphIcon(cssClass);

            return this;
        }

        public ActionLinkButtonControl<TModel> AutoFocus(bool isFocused = true)
        {
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            if (isFocused)
            {
                this.controlHtmlAttributes.AddIfNotExist("autofocus", null);
            }
            else
            {
                this.controlHtmlAttributes.Remove("autofocus");
            }

            return this;
        }

        public ActionLinkButtonControl<TModel> ButtonBlock()
        {
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.buttonBlock = true;

            return this;
        }

        public ActionLinkButtonControl<TModel> Disabled(bool isDisabled = true)
        {
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.disabled = isDisabled;

            return this;
        }

        public ActionLinkButtonControl<TModel> DropDownToggle()
        {
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.isDropDownToggle = true;

            return this;
        }

        public ActionLinkButtonControl<TModel> Fragment(string fragment)
        {
            Contract.Requires<ArgumentException>(!fragment.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.fragment = fragment;

            return this;
        }

        public ActionLinkButtonControl<TModel> HostName(string hostName)
        {
            Contract.Requires<ArgumentException>(!hostName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.hostName = hostName;

            return this;
        }

        public ActionLinkButtonControl<TModel> LinkTextAsHtml(bool isHtml = true)
        {
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.isTextHtml = isHtml;

            return this;
        }

        public ActionLinkButtonControl<TModel> LoadingText(string loadingText)
        {
            Contract.Requires<ArgumentException>(!loadingText.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.loadingText = loadingText;

            return this;
        }

        public ActionLinkButtonControl<TModel> Name(string name)
        {
            Contract.Requires<ArgumentException>(!name.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.name = name;

            return this;
        }

        public ActionLinkButtonControl<TModel> PrependIcon(GlyphIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.iconPrepend = icon;

            return this;
        }

        public ActionLinkButtonControl<TModel> PrependIcon(GlyphIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.iconPrepend = new GlyphIcon(icon, isWhite);

            return this;
        }

        public ActionLinkButtonControl<TModel> PrependIcon(FontAwesomeIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.iconPrepend = icon;

            return this;
        }

        public ActionLinkButtonControl<TModel> PrependIcon(FontAwesomeIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.iconPrepend = new FontAwesomeIcon(icon, isWhite);

            return this;
        }

        public ActionLinkButtonControl<TModel> PrependIcon(string cssClass)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.iconPrepend = new GlyphIcon(cssClass);

            return this;
        }

        public ActionLinkButtonControl<TModel> Protocol(string protocol)
        {
            Contract.Requires<ArgumentException>(!protocol.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.protocol = protocol;

            return this;
        }

        public ActionLinkButtonControl<TModel> RouteName(string routeName)
        {
            Contract.Requires<ArgumentException>(!routeName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.routeName = routeName;

            return this;
        }

        public ActionLinkButtonControl<TModel> RouteValues(object routeValues)
        {
            Contract.Requires<ArgumentNullException>(routeValues != null, "routeValues");
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.routeValues.MergeHtmlAttributes(routeValues.ToDictionary());

            return this;
        }

        public ActionLinkButtonControl<TModel> RouteValues(RouteValueDictionary routeValues)
        {
            Contract.Requires<ArgumentNullException>(routeValues != null, "routeValues");
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.routeValues.MergeHtmlAttributes(routeValues);

            return this;
        }

        public ActionLinkButtonControl<TModel> Style(ButtonStyle style)
        {
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.style = style;

            return this;
        }

        public ActionLinkButtonControl<TModel> Size(ButtonSize size)
        {
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.size = size;

            return this;
        }

        public ActionLinkButtonControl<TModel> Text(string text)
        {
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.text = text;

            return this;
        }

        public ActionLinkButtonControl<TModel> Tooltip(Tooltip tooltip)
        {
            Contract.Requires<ArgumentNullException>(tooltip != null, "tooltip");
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.tooltip = tooltip;

            return this;
        }

        public ActionLinkButtonControl<TModel> Tooltip(string text)
        {
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.tooltip = new Tooltip(text);

            return this;
        }

        public ActionLinkButtonControl<TModel> Tooltip(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.tooltip = new Tooltip(html);

            return this;
        }

        public ActionLinkButtonControl<TModel> Value(string value)
        {
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.value = value;

            return this;
        }

        public ActionLinkButtonControl<TModel> Title(string title)
        {
            Contract.Requires<ArgumentException>(!title.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.title = title;
            return this;
        }

        internal ActionLinkButtonControl<TModel> AlertLink()
        {
            Contract.Ensures(Contract.Result<ActionLinkButtonControl<TModel>>() != null);

            this.ControlClass("alert-link");

            return this;
        }

        private string GenerateActionLink(string linkText, IDictionary<string, object> htmlAttributes)
        {
            Contract.Requires<ArgumentException>(!linkText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            switch (this.actionTypePassed)
            {
                case ActionType.HtmlRegular:
                    {
                        return this.html.ActionLink(linkText, this.actionName, this.controllerName, this.protocol, this.hostName, this.fragment, this.routeValues, htmlAttributes).ToHtmlString();
                    }
                case ActionType.HtmlActionResult:
                    {
                        return this.html.ActionLink(linkText, this.result, htmlAttributes, this.protocol, this.hostName, this.fragment).ToHtmlString();
                    }
                case ActionType.HtmlTaskResult:
                    {
                        return this.html.ActionLink(linkText, this.taskResult, htmlAttributes, this.protocol, this.hostName, this.fragment).ToHtmlString();
                    }
                case ActionType.AjaxRegular:
                    {
                        return this.ajax.ActionLink(linkText, this.actionName, this.controllerName, this.protocol, this.hostName, this.fragment, this.routeValues, this.ajaxOptions, htmlAttributes).ToHtmlString();
                    }
                case ActionType.AjaxActionResult:
                    {
                        return this.ajax.ActionLink(linkText, this.result, this.ajaxOptions, htmlAttributes).ToHtmlString();
                    }
                case ActionType.AjaxTaskResult:
                    {
                        return this.ajax.ActionLink(linkText, this.taskResult, this.ajaxOptions, htmlAttributes).ToHtmlString();
                    }
            }

            return string.Empty;
        }

        protected override string Render()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            IDictionary<string, object> attributes = this.controlHtmlAttributes.FormatHtmlAttributes();

            if (this.tooltip != null)
            {
                attributes.MergeHtmlAttributes(this.tooltip.ToDictionary());
            }

            attributes.AddClass("btn");

            if (!this.id.IsNullOrWhiteSpace())
            {
                attributes.AddOrReplace("id", this.id);
            }

            attributes.AddClass(Helpers.GetCssClass(this.size));
            attributes.AddClass(Helpers.GetCssClass(this.html, this.style));

            if (this.buttonBlock)
            {
                attributes.AddClass("btn-block");
            }

            if (this.isDropDownToggle)
            {
                attributes.AddClass("dropdown-toggle");
                attributes.AddIfNotExist("data-toggle", "dropdown");
            }

            if (this.disabled)
            {
                attributes.AddClass("disabled");
                //x attributes.Add("disabled", "");
            }

            if (!this.loadingText.IsNullOrWhiteSpace())
            {
                attributes.AddOrReplace("data-loading-text", this.loadingText);
            }

            if (!this.title.IsNullOrWhiteSpace())
            {
                attributes.Add("title", this.title);
            }

            if (!this.name.IsNullOrWhiteSpace())
            {
                attributes.Add("name", this.name);
            }

            string replaceMe = Guid.NewGuid().ToString();
            string linkText = this.text;
            string linkHtml = this.GenerateActionLink(replaceMe, attributes);

            if (this.iconPrepend != null || this.iconAppend != null)
            {
                string prepend = string.Empty;
                string append = string.Empty;
                if (this.iconPrepend != null)
                {
                    prepend = this.iconPrepend.ToHtmlString();
                }
                if (this.iconAppend != null)
                {
                    append = this.iconAppend.ToHtmlString();
                }
                StringBuilder html = new StringBuilder();
                html.Append(prepend);
                if (html.Length > 0 && !this.text.IsNullOrWhiteSpace())
                {
                    html.Append(" ");
                }
                html.Append(replaceMe);
                if (html.Length > 0 && this.iconAppend != null)
                {
                    html.Append(" ");
                }
                html.Append(append);

                linkText = html.ToString().Replace(replaceMe, this.text);
            }

            return MvcHtmlString.Create(linkHtml.Replace(replaceMe, linkText)).ToString();
        }
    }
}